namespace MessageSender.Persistence.Configurations;

public class CountryProviderConfiguration : IEntityTypeConfiguration<CountryProvider>
{
    public void Configure(EntityTypeBuilder<CountryProvider> builder)
    {
        builder.ToTable("country_provider");
        builder.HasKey(cp => cp.CountryProviderId)
            .HasName("country_provider_pk");

        builder.Property(cp => cp.CountryProviderId)
            .HasColumnName("country_provider_id");

        builder.Property(cp => cp.ProviderId)
            .HasColumnName("provider_id")
            .IsRequired();

        builder.Property(cp => cp.Alpha2Code)
            .HasColumnName("alpha_2_code")
            .IsRequired();

        builder.Property(p => p.Priority)
            .HasColumnName("priority")
            .HasColumnType("SMALLINT")
            .HasDefaultValueSql(short.MaxValue.ToString())
            .IsRequired();

        builder.Property(cp => cp.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.HasOne(cp => cp.Country)
            .WithMany(c => c.CountryProviders)
            .HasForeignKey(cp => cp.Alpha2Code)
            .HasConstraintName("country_provider_country_alpha_2_code_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(cp => cp.Alpha2Code)
            .HasDatabaseName("alpha_2_code_idx");

        builder.HasOne(cp => cp.Provider)
            .WithMany(p => p.CountryProviders)
            .HasForeignKey(cp => cp.ProviderId)
            .HasConstraintName("country_provider_provider_provider_id_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(cp => cp.ProviderId)
            .HasDatabaseName("provider_id_idx");
    }
}