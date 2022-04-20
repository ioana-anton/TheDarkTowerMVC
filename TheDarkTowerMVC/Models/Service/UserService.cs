using AutoMapper;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;
using TheDarkTowerMVC.Utils;

namespace TheDarkTowerMVC.Models.Service
{
    public class UserService
    {
        private readonly UserRepo _userRepo;
        private readonly IMapper _mapper;


        public UserService(UserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userRepo.GetUserById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUser(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
            user.Password = Encryption.CreateMd5(user.Password);
            await _userRepo.InsertNewUser(user);
            return await GetUserById(user.Id);
        }

        public async Task<UserDTO?> LoginUser(LoginUserDTO loginUserDTO)
        {
            var user = _userRepo.GetUserByLogin(loginUserDTO);

            Console.WriteLine("UserService; Method: LoginUser; user: username= " + user?.Email + " password= " + user?.Password);

            if (user == null) return null;
            return _mapper.Map<UserDTO>(user);
        }
    }
}
