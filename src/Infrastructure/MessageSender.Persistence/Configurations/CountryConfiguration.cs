namespace MessageSender.Persistence.Configurations;

public class CountyConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("country");

        builder.HasKey(c => c.Alpha2Code)
            .HasName("country_pk");

        builder.HasIndex(c => c.DialCode)
            .HasDatabaseName("country_dial_code_idx");

        builder.Property(c => c.Alpha2Code)
            .HasColumnName("alpha_2_code")
            .HasColumnType("varchar(2)")
            .IsRequired();

        builder.Property(c => c.DialCode)
            .HasColumnName("dial_code")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(c => c.AreaCode)
            .HasColumnName("area_code")
            .HasColumnType("varchar(8)")
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .IsRequired();
    }
}