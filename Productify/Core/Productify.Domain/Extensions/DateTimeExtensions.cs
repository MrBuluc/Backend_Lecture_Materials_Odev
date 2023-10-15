namespace Productify.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? SetKindUtc(this DateTime? dateTime) => dateTime.HasValue ? dateTime.Value.SetKindUtc() : null;

        public static DateTime SetKindUtc(this DateTime dateTime) => dateTime.Kind == DateTimeKind.Utc ? dateTime : DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }
}
