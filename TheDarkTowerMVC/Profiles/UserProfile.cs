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
            CreateMap<UserDTO, LoginUserDTO>();
            CreateMap<LoginUserDTO, UserDTO>();
            CreateMap<AddFriendDTO, User>();
            CreateMap<User, AddFriendDTO>();
            // CreateMap<List<User>, List<UserDTO>>();
            // CreateMap<List<UserDTO>, List<User>>();
        }
    }
}
