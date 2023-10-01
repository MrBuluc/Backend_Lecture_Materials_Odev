using Freelancer.Abstract;
using Freelancer.Common;
using Newtonsoft.Json;

namespace Freelancer.Entities
{
    internal class Freelancer : Person<Guid>, ICSVConvertible, IJSONConvertible
    {
        public Freelancer() : base(Guid.Empty, DateTimeOffset.Now, "", "")
        {
        }

        public Freelancer(Guid id, DateTimeOffset createdOn, string firstName, string lastName, string workExperince) : base(id, createdOn, firstName, lastName)
        {
            WorkExperince = workExperince;
            Reviews = new List<Review>();
        }

        public string WorkExperince { get; set; }
        public List<Review> Reviews { get; set; }

        public void FromJSON(Dictionary<string, dynamic> json)
        {
            Id = Guid.Parse(json["Id"]);
            CreatedOn = DateTimeOffset.Parse(json["CreatedOn"]);
            FirstName = json["FirstName"];
            LastName = json["LastName"];
            WorkExperince = json.GetValueOrDefault("WorkExperince");
            Reviews = new List<Review>();
            List<Dictionary<string, dynamic>>? reviewJsonList = json["Reviews"].ToObject<List<Dictionary<string, dynamic>>>();
            foreach (Dictionary<string, dynamic> reviewJson in reviewJsonList)
            {
                Review review = new Review();
                review.FromJSON(reviewJson);
                Reviews.Add(review);
            }
        }

        public string GetValuesCSV() => $"{Id},{CreatedOn},{FirstName},{LastName}, {WorkExperince}, {Reviews}";

        public void SetValuesCSV(string csv)
        {
            string[] data = csv.Split(',');
            Id = Guid.Parse(data[0]);
            CreatedOn = DateTimeOffset.Parse(data[1]);
            FirstName = data[2];
            LastName = data[3];
            WorkExperince = data[4];

        }

        public Dictionary<string, dynamic> ToJSON()
        {
            Dictionary<string, dynamic> json = new();
            json["Id"] = Id.ToString();
            json["CreatedOn"] = CreatedOn.ToString();
            json["FirstName"] = FirstName;
            json["LastName"] = LastName;
            json["WorkExperince"] = WorkExperince;
            json["Reviews"] = Reviews.ConvertAll<Dictionary<string, dynamic>>(review => review.ToJSON());
            return json;
        }

        public override string? ToString() => $"Freelancer(Id: {Id}, CreatedOn: {CreatedOn}, FirstName: {FirstName}, LastName: {LastName}, WorkExperince: {WorkExperince}, Reviews: {Reviews})";
    }
}
