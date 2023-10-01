using Freelancer.Abstract;
using Freelancer.Common;

namespace Freelancer.Entities
{
    internal class Review : EntityBase<int>, IJSONConvertible
    {
        public string Text { get; set; }
        public int Rating { get; set; }

        public Review() : base(0, DateTimeOffset.Now)
        {
        }

        public Review(int ıd, DateTimeOffset createdOn, string text, int rating) : base(ıd, createdOn)
        {
            Text = text;
            Rating = rating;
        }

        public void FromJSON(Dictionary<string, dynamic> json)
        {
            Id = Convert.ToInt32(json["Id"]);
            CreatedOn = DateTimeOffset.Parse(json["CreatedOn"]);
            Text = json["Text"];
            Rating = Convert.ToInt32(json["Rating"]);
        }

        public Dictionary<string, dynamic> ToJSON()
        {
            Dictionary<string, dynamic> json = new();
            json["Id"] = Id;
            json["CreatedOn"] = CreatedOn.ToString();
            json["Text"] = Text;
            json["Rating"] = Rating;
            return json;
        }

        public override string? ToString() => $"Review(Id: {Id}, CreatedOn: {CreatedOn}, Text: {Text}, Rating: {Rating})";

    }
}
