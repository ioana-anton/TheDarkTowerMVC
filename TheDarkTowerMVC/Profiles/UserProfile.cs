using AutoMapper;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
