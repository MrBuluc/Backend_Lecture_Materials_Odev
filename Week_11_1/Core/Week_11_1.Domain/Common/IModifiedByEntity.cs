namespace Week_11_1.Domain.Common
{
    public interface IModifiedByEntity
    {
        DateTimeOffset? ModifiedOn { get; set; }
        string? ModifiedByUserId { get; set; }
    }
}
