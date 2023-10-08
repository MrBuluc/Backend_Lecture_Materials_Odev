using Week_4_1.Common;

namespace Week_4_1.Entities
{
    public class Review : EntityBase<int>
    {
        public string Text { get; set; }
        public int Rating { get; set; }

        public Review(int ıd, DateTimeOffset createdOn, string text, int rating) : base(ıd, createdOn)
        {
            Text = text;
            Rating = rating;
        }

        public override string? ToString() => $"Review(Id: {Id}, CreatedOn: {CreatedOn}, Text: {Text}, Rating: {Rating})";

    }
}
