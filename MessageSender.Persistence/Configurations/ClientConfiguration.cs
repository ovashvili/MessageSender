namespace MessageSender.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("client");
        builder.HasKey(c => c.ClientId)
            .HasName("client_pk");

        builder.Property(c => c.ClientId)
            . HasColumnName("client_id")
            .HasColumnType("CHAR(36)");

        builder.Property(c => c.Config)
            .HasColumnName("config")
            .HasColumnType("json")
            .IsRequired();

        builder.Property(c => c.Secret)
            .HasColumnName("secret")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .IsRequired();
    }
}