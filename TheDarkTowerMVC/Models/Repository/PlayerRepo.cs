using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.Data;

namespace TheDarkTowerMVC.Models.Repository
{
    public class PlayerRepo
    {
        private readonly DatabaseContext databaseContext;

        public PlayerRepo(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
        }




    }
}
