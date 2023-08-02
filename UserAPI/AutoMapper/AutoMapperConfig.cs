using AutoMapper;
using UserAPI.Entity;
using UserAPI.Models;

namespace UserAPI.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserViewModel, User>();
        }
    }
}
