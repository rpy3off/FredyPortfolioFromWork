﻿using Shared.Models;
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

        internal async Task GetCategoriesFromDatabaseAndCache()
        {
            _categories = await _httpClient.GetFromJsonAsync<List<Category>>("endpoint");
        }

        internal event Action OnCategoriesDataChanged;
        private void NotifyCategoriesDataCHanged()
        {
            OnCategoriesDataChanged?.Invoke();
        }
    }
}
