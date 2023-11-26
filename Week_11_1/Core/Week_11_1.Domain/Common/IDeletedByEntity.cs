namespace Week_11_1.Domain.Common
{
    public interface IDeletedByEntity
    {
        DateTimeOffset? DeletedOn { get; set; }
        string? DeletedByUserId { get; set; }
        bool? IsDeleted { get; set; }
    }
}
