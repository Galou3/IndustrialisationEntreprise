namespace IndustrialisationEntreprise.Pages;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Entrepot> Entrepots { get; set; }
}
