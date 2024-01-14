namespace MessageSender.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");
        builder.HasKey(c => c.ClientId)
            .HasName("PK_Client");

        builder.Property(c => c.ClientId)
            .HasColumnName("ClientId")
            .HasColumnType("uniqueidentifier"); 
        
        builder.Property(c => c.Config)
            .HasColumnName("Config")
            .HasColumnType("nvarchar(2000)")
            .IsRequired();
            
        builder.Property(c => c.Secret)
            .HasColumnName("Secret")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();
    }
}