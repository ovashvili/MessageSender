using MessageSender.Persistence.Extensions;

namespace MessageSender.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryProvider> CountryProviders { get; set; }
    public DbSet<GreyList> GreyList { get; set; }
    public DbSet<MessageDelivery> MessageDelivery { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Sms> Smses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Seed();
            
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
