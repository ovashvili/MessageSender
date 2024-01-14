namespace MessageSender.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");

        builder.HasKey(c => c.Alpha2Code)
            .HasName("PK_Country");

        builder.HasIndex(c => c.DialCode)
            .HasDatabaseName("IX_Country_DialCode");

        builder.Property(c => c.Alpha2Code)
            .HasColumnName("Alpha2Code")
            .HasColumnType("char(2)")
            .IsRequired();

        builder.Property(c => c.DialCode)
            .HasColumnName("DialCode")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();
    }
}