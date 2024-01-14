namespace MessageSender.Persistence.Configurations;

public class CountryProviderConfiguration : IEntityTypeConfiguration<CountryProvider>
{
    public void Configure(EntityTypeBuilder<CountryProvider> builder)
    {
        builder.ToTable("CountryProvider");
        builder.HasKey(cp => cp.CountryProviderId)
            .HasName("PK_CountryProvider");

        builder.Property(cp => cp.CountryProviderId)
            .HasColumnName("CountryProviderId");

        builder.Property(cp => cp.ProviderId)
            .HasColumnName("ProviderId")
            .IsRequired();

        builder.Property(cp => cp.Alpha2Code)
            .HasColumnName("Alpha2Code")
            .IsRequired();

        builder.Property(p => p.Priority)
            .HasColumnName("Priority")
            .HasColumnType("SMALLINT")
            .HasDefaultValueSql(short.MaxValue.ToString())
            .IsRequired();

        builder.Property(cp => cp.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.HasOne(cp => cp.Country)
            .WithMany(c => c.CountryProviders)
            .HasForeignKey(cp => cp.Alpha2Code)
            .HasConstraintName("FK_CountryProvider_Country_Alpha2Code")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(cp => cp.Alpha2Code)
            .HasDatabaseName("IX_CountryProvider_Alpha2Code");

        builder.HasOne(cp => cp.Provider)
            .WithMany(p => p.CountryProviders)
            .HasForeignKey(cp => cp.ProviderId)
            .HasConstraintName("FK_CountryProvider_Provider_ProviderId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(cp => cp.ProviderId)
            .HasDatabaseName("IX_CountryProvider_ProviderId");
    }
}