using Freelancer.Abstract;
using Freelancer.Common;

namespace Freelancer.Entities
{
    public class Customer : Person<Guid>, ICSVConvertible, IJSONConvertible
    {
        public string PhoneNumber { get; set; }

        public Customer() : base(Guid.Empty, DateTimeOffset.Now, "", "")
        {
        }

        public Customer(Guid id, DateTimeOffset createdOn, string firstName, string lastName, string phoneNumber) : base(id, createdOn, firstName, lastName)
        {
            PhoneNumber = phoneNumber;
        }

        public string GetValuesCSV() => $"{Id},{CreatedOn},{FirstName},{LastName},{PhoneNumber}";

        public void SetValuesCSV(string csv)
        {
            string[] data = csv.Split(',');
            Id = Guid.Parse(data[0]);
            CreatedOn = DateTimeOffset.Parse(data[1]);
            FirstName = data[2];
            LastName = data[3];
            PhoneNumber = data[4];
        }

        public void FromJSON(Dictionary<string, dynamic> json) 
        { 
            Id = Guid.Parse(json["Id"]);
            CreatedOn = DateTimeOffset.Parse(json["CreatedOn"]);
            FirstName = json["FirstName"];
            LastName = json["LastName"];
            PhoneNumber = json["PhoneNumber"];
        }

        public Dictionary<string, dynamic> ToJSON()
        {
            Dictionary<string, dynamic> json = new();
            json["Id"] = Id.ToString();
            json["CreatedOn"] = CreatedOn.ToString();
            json["FirstName"] = FirstName;
            json["LastName"] = LastName;
            json["PhoneNumber"] = PhoneNumber;
            return json;
        }

        public override string? ToString()
        {
            return $"Customer(Id: {Id}, CreatedOn: {CreatedOn}, FirstName: {FirstName}, LastName: {LastName}, PhoneNumber: {PhoneNumber})";
        }
    }
}
