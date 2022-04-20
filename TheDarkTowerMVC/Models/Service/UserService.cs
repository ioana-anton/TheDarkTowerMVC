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
        private readonly ILogger<UserService> _logger;


        public UserService(UserRepo userRepo, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
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
            _logger.LogInformation("UserService; User id inserat: " + user.Id);
            return await GetUserById(user.Id);
        }

        public async Task<UserDTO?> LoginUser(LoginUserDTO loginUserDTO)
        {
            loginUserDTO.Password = Encryption.CreateMd5(loginUserDTO.Password);
            var user = _userRepo.GetUserByLogin(loginUserDTO);



            if (user == null)
            {
                _logger.LogError(Error.USERSERVICE_USER_SELECT);
                return null;
            }
            else
            {
                _logger.LogInformation("UserService; Method: LoginUser; user: username= " + user?.Username + " password= " + user?.Password);

            }
            return _mapper.Map<UserDTO>(user);
        }
    }
}
