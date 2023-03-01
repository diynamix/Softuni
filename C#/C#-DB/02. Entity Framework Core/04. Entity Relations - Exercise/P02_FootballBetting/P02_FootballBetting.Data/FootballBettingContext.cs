namespace P02_FootballBetting.Data;

// Built-in libraries namespaces

// Third-party packages namespaces
using Microsoft.EntityFrameworkCore;

// Solution namespaces
using Common;
using Models;

public class FootballBettingContext : DbContext
{
    // Use it when developing the application
    // When we test the application localy
    public FootballBettingContext()
    {

    }

    // Used by Judge
    // Loading of the DbContext with DI(dependancy injection) -> in real application it is usefull
    public FootballBettingContext(DbContextOptions options)
        : base(options)
    {

    }

    public DbSet<Bet> Bets { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<User> Users { get; set; }

    // Connection configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Set default connection string
            // Someone use empty constructor of our DbContext
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    // Fluent API and Entities Config
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Team>(e =>
        //{
        //	e.HasKey(t => t.TeamId);
        //	e.Property(t => t.TeamId).IsRequired();
        //});

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerStatistic>(entity =>
        {
            entity.HasKey(ps => new { ps.GameId, ps.PlayerId });
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);  
        });
    }
}
