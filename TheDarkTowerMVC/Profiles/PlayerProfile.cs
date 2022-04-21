using AutoMapper;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<CreatedDeckDTO, CardDeck>();
            CreateMap<CardDeck, CreatedDeckDTO>();
            CreateMap<CardDeckDTO, CardDeck>();
            CreateMap<CardDeck, CardDeckDTO>();

        }
    }
}
