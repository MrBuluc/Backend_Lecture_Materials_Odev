using Week_4_1.Common;

namespace Week_4_1.Entities
{
    public class Freelancer : Person<Guid>
    {
        public string WorkExperince { get; set; }
        public List<Review> Reviews { get; set; }

        public Freelancer(Guid id, DateTimeOffset createdOn, string firstName, string lastName, string workExperince) : base(id, createdOn, firstName, lastName)
        {
            WorkExperince = workExperince;
            Reviews = new List<Review>();
        }

        public double GetAverageRating()
        {
            double sum = 0;

            foreach (Review review in Reviews)
            {
                sum += review.Rating;
            }

            return sum / Reviews.Count;
        }

        public override string? ToString() => $"Freelancer(Id: {Id}, CreatedOn: {CreatedOn}, FirstName: {FirstName}, LastName: {LastName}, WorkExperince: {WorkExperince}, Reviews: {Reviews})";
    }
}
