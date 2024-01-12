using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageSender.Persistence.Configurations;

public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.ToTable("provider");
        builder.HasKey(p => p.ProviderId)
            .HasName("provider_pk");

        builder.HasIndex(p => p.Name)
            .IsUnique()
            .HasDatabaseName("provider_provider_name_uq");

        builder.Property(p => p.ProviderId)
            .HasColumnName("provider_id");

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(64)")
            .IsRequired();

        builder.Property(p => p.Config)
            .HasColumnName("config")
            .HasColumnType("json")
            .IsRequired();

        builder.Property(p => p.Priority)
            .HasColumnName("priority")
            .HasColumnType("SMALLINT")
            .HasDefaultValueSql(short.MaxValue.ToString())
            .IsRequired();

        builder.Property(p => p.IsGlobal)
            .HasColumnName("is_global")
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .IsRequired();
    }
}