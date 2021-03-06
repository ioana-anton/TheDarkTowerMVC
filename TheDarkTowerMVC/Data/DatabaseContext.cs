using Microsoft.EntityFrameworkCore;
using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Port=2233;User Id=postgres;Password=postgres;Database=the_dark_tower;");

        //comenzi consola pentru migrations
        // dotnet ef migrations add Classes
        // dotnet ef database drop
        // dotnet ef database update
        //ef migrations remove

        //definirea tabelelor

        public DbSet<User> Users { get; set; }
        public DbSet<CardDeck> CardDecks { get; set; }
        public DbSet<GameCard> GameCard { get; set; }

        public DbSet<Inbox> Inbox { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Friend> FriendList { get; set; }

        public DbSet<CardDeckGameCard> CardDeckGameCard { get; set; }


        //new thingy
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<CardDeck>().ToTable("CardDeck");
            modelBuilder.Entity<GameCard>().ToTable("GameCard");
            modelBuilder.Entity<Inbox>().ToTable("Inbox");
            modelBuilder.Entity<Recipient>().ToTable("Recipient");
            modelBuilder.Entity<Friend>().ToTable("Friend");
            modelBuilder.Entity<CardDeckGameCard>().ToTable("CardDeckGameCard");

            modelBuilder.Entity<CardDeckGameCard>().HasKey(sc => new { sc.GameCardId, sc.CardDeckId });

            modelBuilder.Entity<CardDeckGameCard>()
                 .HasOne<CardDeck>(sc => sc.CardDeck)
                 .WithMany(s => s.CardDeckGameCards)
                 .HasForeignKey(sc => sc.CardDeckId);


            modelBuilder.Entity<CardDeckGameCard>()
                         .HasOne<GameCard>(sc => sc.GameCard)
                         .WithMany(s => s.CardDeckGameCards)
                         .HasForeignKey(sc => sc.GameCardId);
        }

    }
}
