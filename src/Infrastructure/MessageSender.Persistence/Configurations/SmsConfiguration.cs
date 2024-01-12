namespace MessageSender.Persistence.Configurations;

public class SmsConfiguration : IEntityTypeConfiguration<Sms>
{
    public void Configure(EntityTypeBuilder<Sms> builder)
    {
        builder.ToTable("sms");
        builder.HasKey(s => s.SmsId)
            .HasName("sms_pk");

        builder.HasIndex(cp => cp.ClientId)
            .HasDatabaseName("client_id_idx");

        builder.Property(s => s.SmsId)
            .HasColumnName("sms_id")
            .HasColumnType("bigint");

        builder.Property(s => s.PhoneNumber)
            .HasColumnName("phone_number")
            .HasColumnType("varchar(32)")
            .IsRequired();

        builder.Property(s => s.Message)
            .HasColumnName("message")
            .HasColumnType("text");

        builder.Property(s => s.CreateDate)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnName("create_date")
            .IsRequired();

        builder.Property(e => e.ClientId)
            .HasColumnName("client_id");

        builder.HasOne(e => e.Client)
            .WithMany(c => c.Smses)
            .HasForeignKey(cp => cp.ClientId)
            .HasConstraintName("sms_client_client_id_fk");
    }
}