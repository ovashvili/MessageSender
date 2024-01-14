namespace MessageSender.Persistence.Configurations;

public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.ToTable("Provider");
        builder.HasKey(p => p.ProviderId)
            .HasName("PK_Provider");

        builder.HasIndex(p => p.Name)
            .IsUnique()
            .HasDatabaseName("IX_Provider_Name_UQ");

        builder.Property(p => p.ProviderId)
            .HasColumnName("ProviderId");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(64)")
            .IsRequired();

        builder.Property(p => p.Config)
            .HasColumnName("Config")
            .HasColumnType("nvarchar(2000)"); 
        
        builder.Property(p => p.Priority)
            .HasColumnName("Priority")
            .HasColumnType("SMALLINT")
            .HasDefaultValueSql(short.MaxValue.ToString())
            .IsRequired();

        builder.Property(p => p.IsGlobal)
            .HasColumnName("IsGlobal")
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();
    }
}