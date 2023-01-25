﻿using Client.Static;
using Shared.Models;
using System.Net.Http.Json;

namespace Client.Services
{
    internal sealed class InMemoryDatabaseCache
    {
        private readonly HttpClient _httpClient;

        public InMemoryDatabaseCache(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private List<Category> _categories = null;
        internal List<Category> Categories 
        { 
            get 
            {
                return _categories; 
            } 
            set
            {
                _categories = value;
                NotifyCategoriesDataCHanged();
            }
        }

        internal async Task<Category> GetCategoryByCategoryId(int categoryId)
        {
            if (_categories == null)
            {
                await GetCategoriesFromDatabaseAndCache();
            }

            return _categories.First(category => category.CategoryId == categoryId);
        }

        private bool _gettingGetCategoriesFromDatabaseAndCache = false;
        internal async Task GetCategoriesFromDatabaseAndCache()
        {

            // Only allow one Get request ro run at a time.
            if (_gettingGetCategoriesFromDatabaseAndCache == false)
            {
                _gettingGetCategoriesFromDatabaseAndCache = true;
                _categories = await _httpClient.GetFromJsonAsync<List<Category>>(APIEndpoints.s_categories);
                _gettingGetCategoriesFromDatabaseAndCache = false;
            }
            
        }

        internal event Action OnCategoriesDataChanged;
        private void NotifyCategoriesDataCHanged()
        {
            OnCategoriesDataChanged?.Invoke();
        }
    }
}
