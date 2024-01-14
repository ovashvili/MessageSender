using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MessageSender.Domain.Enums;

namespace MessageSender.Persistence.Configurations;

public class MessageDeliveryConfiguration : IEntityTypeConfiguration<MessageDelivery>
{
    public void Configure(EntityTypeBuilder<MessageDelivery> builder)
    {
        builder.ToTable("MessageDelivery");
        builder.HasKey(md => md.MessageDeliveryId)
            .HasName("PK_MessageDelivery");

        builder.HasIndex(md => md.SmsId)
            .HasDatabaseName("IX_MessageDelivery_SmsId");

        builder.HasIndex(md => md.ProviderId)
            .HasDatabaseName("IX_MessageDelivery_ProviderId");

        builder.Property(md => md.MessageDeliveryId)
            .HasColumnType("bigint")
            .HasColumnName("MessageDeliveryId");

        builder.Property(md => md.Status)
            .HasColumnName("Status")
            .HasColumnType("varchar(32)")
            .HasComment($"Possible Values:\n{string.Join('\n', Enum.GetNames<MessageDeliveryStatus>())}")
            .HasConversion(new EnumToStringConverter<MessageDeliveryStatus>())
            .IsRequired();

        builder.Property(md => md.StatusNote)
            .HasColumnName("StatusNote")
            .HasColumnType("nvarchar(511)"); 
        
        builder.Property(md => md.ProviderMessageId)
            .HasColumnName("ProviderMessageId")
            .HasColumnType("varchar(64)");

        builder.Property(md => md.CreateDate)
            .HasColumnName("CreateDate")
            .HasColumnType("datetime2")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(md => md.ModifyDate)
            .HasColumnName("ModifyDate")
            .HasColumnType("datetime2")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(md => md.SmsId)
            .HasColumnName("SmsId")
            .HasColumnType("bigint");

        builder.Property(md => md.ProviderId)
            .HasColumnName("ProviderId")
            .HasColumnType("int");

        builder.HasOne(md => md.Sms)
            .WithMany(s => s.MessageDeliveries)
            .HasForeignKey(md => md.SmsId)
            .HasConstraintName("FK_MessageDelivery_Sms_SmsId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(md => md.Provider)
            .WithMany(p => p.MessageDeliveries)
            .HasForeignKey(md => md.ProviderId)
            .HasConstraintName("FK_MessageDelivery_Provider_ProviderId")
            .OnDelete(DeleteBehavior.SetNull);
    }
}