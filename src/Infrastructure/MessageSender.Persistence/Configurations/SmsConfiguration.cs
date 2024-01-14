namespace MessageSender.Persistence.Configurations;

public class SmsConfiguration : IEntityTypeConfiguration<Sms>
{
    public void Configure(EntityTypeBuilder<Sms> builder)
    {
        builder.ToTable("Sms");
        builder.HasKey(s => s.SmsId)
            .HasName("PK_Sms");

        builder.HasIndex(cp => cp.ClientId)
            .HasDatabaseName("IX_Sms_ClientId");

        builder.Property(s => s.SmsId)
            .HasColumnName("SmsId")
            .HasColumnType("bigint");

        builder.Property(s => s.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasColumnType("varchar(32)")
            .IsRequired();

        builder.Property(s => s.Message)
            .HasColumnName("Message")
            .HasColumnType("nvarchar(max)");
        
        builder.Property(s => s.CreateDate)
            .HasColumnType("datetime2")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnName("CreateDate")
            .IsRequired();

        builder.Property(e => e.ClientId)
            .HasColumnName("ClientId");

        builder.HasOne(e => e.Client)
            .WithMany(c => c.Smses)
            .HasForeignKey(cp => cp.ClientId)
            .HasConstraintName("FK_Sms_Client_ClientId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}