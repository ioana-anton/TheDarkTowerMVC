using AutoMapper;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.Profiles
{
    public class GameMasterProfile : Profile
    {
        public GameMasterProfile()
        {
            CreateMap<GameCard, AddCardDTO>();
            CreateMap<AddCardDTO, GameCard>();
            CreateMap<GameCard, GameCardDTO>();
            CreateMap<GameCardDTO, GameCard>();
            CreateMap<DeleteCardDTO, GameCard>();
            CreateMap<GameCard, DeleteCardDTO>();
        }
    }
}
