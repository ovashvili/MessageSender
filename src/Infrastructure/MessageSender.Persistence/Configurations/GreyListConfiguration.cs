using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MessageSender.Domain.Enums;

namespace MessageSender.Persistence.Configurations;

public class GreyListConfiguration : IEntityTypeConfiguration<GreyList>
{
    public void Configure(EntityTypeBuilder<GreyList> builder)
    {
        builder.ToTable("GreyList");
        builder.HasKey(g => g.ContactIdentifier)
            .HasName("PK_GreyList");

        builder.Property(g => g.ContactIdentifier)
            .HasColumnName("ContactIdentifier")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(g => g.Status)
            .HasColumnName("Status")
            .HasColumnType("varchar(32)")
            .HasComment($"Possible Values:\n{string.Join('\n', Enum.GetNames<ContactStatus>())}")
            .HasConversion(new EnumToStringConverter<ContactStatus>())
            .IsRequired();

        builder.Property(g => g.StatusNote)
            .HasColumnName("StatusNote")
            .HasColumnType("nvarchar(511)"); 
            
        builder.Property(g => g.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.Property(g => g.CreateDate)
            .HasColumnName("CreateDate")
            .HasColumnType("datetime2")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(g => g.ModifyDate)
            .HasColumnName("ModifyDate")
            .HasColumnType("datetime2")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
    }
}