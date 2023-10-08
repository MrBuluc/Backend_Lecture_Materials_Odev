using Freelancer.Entities;
using Freelancer.Services;

Console.WriteLine("Linq Metotları Uygulama Ödevi");

#region Average

Console.WriteLine("Average");
List<int> numbers = new List<int> { 78, 92, 100, 37, 81 };
Console.WriteLine(numbers.Average());

#endregion

#region Concat
Console.WriteLine("Concat");
foreach (int num in numbers.Concat(new List<int> { 87, 29, 1, 73, 18 }))
{
    Console.WriteLine(num);
}

#endregion

Console.WriteLine("------------------------");

#region Distinct

Console.WriteLine("Distinct");
List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };
foreach (int age in ages.Distinct())
{
    Console.WriteLine(age);
}

#endregion

Console.WriteLine("-----------------------------");

#region Skip

Console.WriteLine("Skip");
int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

foreach (var grade in grades.Skip(4))
{
    Console.WriteLine(grade);
}

#endregion

Console.WriteLine("-------------------");

#region Take

Console.WriteLine("Take");
foreach (int grade in grades.Take(4))
{
    Console.WriteLine(grade);
}
#endregion

Console.WriteLine("---------------------");

#region Aggregate

Console.WriteLine("Aggregate");
NotepadService notepadService = new();
List<Dictionary<string, dynamic>>? customersJsonList = notepadService.GetJson("", truePath: "D:\\Users\\HAKKICAN\\Desktop\\Software\\C#\\YetGen Jump & Akbank Backend Programı Eğitimi\\Freelancer\\Database\\Customers.json");
List<Customer> customers = new();
foreach (Dictionary<string, dynamic> customerJson in customersJsonList)
{
    Customer customer = new();
    customer.FromJSON(customerJson);
    customers.Add(customer);
}

Customer aggregateCustomer = new();
aggregateCustomer.CreatedOn = new DateTime(2023, 9, 19);
Console.WriteLine($"Customer which was created lastly: {customers.Aggregate(aggregateCustomer, (conditionCustomer, next) => next.CreatedOn > conditionCustomer.CreatedOn ? next : conditionCustomer, customer => $"{customer.FirstName} {customer.LastName}")}");
#endregion

Console.WriteLine("-------------------");

#region Contains

Console.WriteLine("Contains");
Console.WriteLine(grades.Contains(100));
#endregion

Console.WriteLine("-----------------------");

#region Except

Console.WriteLine("Except");
List<double> numbers1 = new() { 2.0, 2.0, 2.1, 2.2, 2.3, 2.3, 2.4, 2.5 };

foreach (double num in numbers1.Except(new List<double>() { 2.2, 2.3 }))
{
    Console.WriteLine(num);
}
#endregion

Console.WriteLine("---------------------------");

#region GroupBy

Console.WriteLine("GroupBy");

List<Dictionary<string, dynamic>>? freelancersJsonList = notepadService.GetJson("", truePath: "D:\\Users\\HAKKICAN\\Desktop\\Software\\C#\\YetGen Jump & Akbank Backend Programı Eğitimi\\Freelancer\\Database\\Freelancers.json");
List<Freelancer.Entities.Freelancer> freelancers = new();
foreach (Dictionary<string, dynamic> freelancerJson in freelancersJsonList)
{
    Freelancer.Entities.Freelancer freelancer = new();
    freelancer.FromJSON(freelancerJson);
    freelancers.Add(freelancer);
}

foreach (var result in freelancers.GroupBy(freelancer => Math.Floor(freelancer.GetAverageRating()), freelancer => freelancer.GetAverageRating(), (baseRating, ratings) => new {Key = baseRating, Count = ratings.Count(), Min = ratings.Min(), Max = ratings.Max()}))
{
    Console.WriteLine($"Rating group: {result.Key}");
    Console.WriteLine($"Number of freelancers in this rating group: {result.Count}");
    Console.WriteLine($"Min rating: {result.Min}");
    Console.WriteLine($"Max rating: {result.Max}");
    Console.WriteLine();
}
#endregion