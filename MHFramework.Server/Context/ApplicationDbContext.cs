namespace MHFramework.Server;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}