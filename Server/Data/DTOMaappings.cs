using AutoMapper;
using Shared.Models;

namespace Server.Data
{
    internal sealed class DTOMaappings : Profile
    {
        public DTOMaappings()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}
