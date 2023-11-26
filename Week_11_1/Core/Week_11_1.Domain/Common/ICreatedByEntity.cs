namespace Week_11_1.Domain.Common
{
    public interface ICreatedByEntity
    {
        DateTimeOffset CreatedOn { get; set; }
        string CreatedByUserId { get; set; }
    }
}
