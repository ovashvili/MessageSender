using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MessageSender.Domain.Enums;

namespace MessageSender.Persistence.Configurations;

public class GreyListConfiguration : IEntityTypeConfiguration<GreyList>
{
    public void Configure(EntityTypeBuilder<GreyList> builder)
    {
        builder.ToTable("greylist");
        builder.HasKey(g => g.ContactIdentifier)
            .HasName("greylist_pk");

        builder.Property(g => g.ContactIdentifier)
            .HasColumnName("contact_identifier")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(g => g.Status)
            .HasColumnName("status")
            .HasColumnType("varchar(32)")
            .HasComment(
                $"Possible Values:\n{string.Join('\n', Enum.GetNames<ContactStatus>())}")
            .HasConversion(new EnumToStringConverter<ContactStatus>())
            .IsRequired();

        builder.Property(g => g.StatusNote)
            .HasColumnName("status_note")
            .HasColumnType("tinytext");

        builder.Property(g => g.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(g => g.CreateDate)
            .HasColumnName("create_date")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(g => g.ModifyDate)
            .HasColumnName("modify_date")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
    }
}