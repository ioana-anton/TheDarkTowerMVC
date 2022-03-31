using Microsoft.EntityFrameworkCore;

namespace TheDarkTowerMVC.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        //comenzi consola pentru migrations
        // dotnet ef migrations add Classes
        // dotnet ef database drop
        // dotnet ef database update

        //definirea tabelelor


    }
}
