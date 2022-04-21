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

        public List<InboxDTO> GetReceivedInbox(string id)
        {
            var inboxes = _userRepo.GetReceivedInbox(id);

            InboxDTOBuilder inboxDTOBuilder = new InboxDTOBuilder();
            List<InboxDTO> inboxDTOList = new List<InboxDTO>();

            foreach (var inbox in inboxes)
            {
                List<UserDTO> recipients = _mapper.Map<List<UserDTO>>(inbox.Recipients);
                //Console.WriteLine("")
                if (recipients == null)
                {
                    Console.WriteLine("UserService; GetReceivedInbox; Didn't find any recipients!!");
                    return null;
                }
                var inboxDTO = inboxDTOBuilder.setSender(inbox.Sender.Id).setRecipients(recipients).setMessage(inbox.Message).build();
                inboxDTOList.Add(inboxDTO);
            }

            return inboxDTOList;
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
