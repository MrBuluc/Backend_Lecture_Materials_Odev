using Freelancer.Entities;
using Freelancer.Services;

NotepadService notepadService = new();
//List<Dictionary<string, dynamic>>? customersJsonList = notepadService.GetJson("Customers");
//List<Customer> customers = new();
//foreach (Dictionary<string, dynamic> customerJson in customersJsonList)
//{
//    Customer customer = new();
//    customer.FromJSON(customerJson);
//    customers.Add(customer);
//}

////foreach (Customer customer in customers)
////{
////    Console.WriteLine(customer);
////}

//notepadService.WriteToJson(new Customer(Guid.NewGuid(), DateTimeOffset.Now, "Console", "App", "09876543210"));

List<Dictionary<string, dynamic>>? freelancersJsonList = notepadService.GetJson("Freelancers");
List<Freelancer.Entities.Freelancer> freelancers = new();
foreach (Dictionary<string, dynamic> freelancerJson in freelancersJsonList)
{
    Freelancer.Entities.Freelancer freelancer = new();
    freelancer.FromJSON(freelancerJson);
    freelancers.Add(freelancer);
}

foreach (Freelancer.Entities.Freelancer freelancer in freelancers)
{
    Console.WriteLine(freelancer);
}

Freelancer.Entities.Freelancer freelancer1 = new(Guid.NewGuid(), DateTimeOffset.Now, "Console", "App", "C#");
freelancer1.Reviews.Add(new Review(8, DateTimeOffset.Now, "Console", 1));
notepadService.WriteToJson(freelancer1);