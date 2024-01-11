using MessageSender.Domain.Enums;

namespace MessageSender.Domain.Entities;

public class GreyList
{
    public string ContactIdentifier { get; set; } = null!;
    public ContactStatus Status { get; set; }
    public string StatusNote { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifyDate { get; set; }
}