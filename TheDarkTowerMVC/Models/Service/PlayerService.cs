using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.Models.Repository;

namespace TheDarkTowerMVC.Models.Service
{
    public class PlayerService
    {
        private readonly PlayerRepo _playerRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PlayerService> _logger;

        public PlayerService(PlayerRepo userRepo, IMapper mapper, ILogger<PlayerService> logger)
        {
            _playerRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
        }


    }
}
