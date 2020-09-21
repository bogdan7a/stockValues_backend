using AutoMapper;
using stockValues_backend.Dtos;
using stockValues_backend.Models;

namespace stockValues_backend.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            //Source => target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}