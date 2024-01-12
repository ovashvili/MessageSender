using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MessageSender.Domain.Enums;

namespace MessageSender.Persistence.Configurations;

public class MessageDeliveryConfiguration : IEntityTypeConfiguration<MessageDelivery>
{
    public void Configure(EntityTypeBuilder<MessageDelivery> builder)
    {
        builder.ToTable("message_delivery");
        builder.HasKey(md => md.MessageDeliveryId)
            .HasName("message_delivery_pk");

        builder.HasIndex(md => md.SmsId)
            .HasDatabaseName("sms_id_idx");

        builder.HasIndex(md => md.ProviderId)
            .HasDatabaseName("provider_id_idx");

        builder.Property(md => md.MessageDeliveryId)
            .HasColumnType("bigint")
            .HasColumnName("message_delivery_id");

        builder.Property(md => md.Status)
            .HasColumnName("status")
            .HasColumnType("varchar(32)")
            .HasComment(
                $"Possible Values:\n{string.Join('\n', Enum.GetNames<MessageDeliveryStatus>())}")
            .HasConversion(new EnumToStringConverter<MessageDeliveryStatus>())
            .IsRequired();

        builder.Property(md => md.StatusNote)
            .HasColumnName("status_note")
            .HasColumnType("tinytext");

        builder.Property(md => md.ProviderMessageId)
            .HasColumnName("provider_message_id")
            .HasColumnType("varchar(64)");

        builder.Property(md => md.CreateDate)
            .HasColumnName("create_date")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(md => md.ModifyDate)
            .HasColumnName("modify_date")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(md => md.SmsId)
            .HasColumnName("sms_id")
            .HasColumnType("bigint");

        builder.Property(md => md.ProviderId)
            .HasColumnName("provider_id")
            .HasColumnType("int");

        builder.HasOne(md => md.Sms)
            .WithMany(s => s.MessageDeliveries)
            .HasForeignKey(md => md.SmsId)
            .HasConstraintName("message_delivery_sms_sms_id_fk")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(md => md.Provider)
            .WithMany(p => p.MessageDeliveries)
            .HasForeignKey(md => md.ProviderId)
            .HasConstraintName("message_delivery_provider_provider_id_fk")
            .OnDelete(DeleteBehavior.SetNull);
    }
}