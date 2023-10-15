using Week_5_2.Contexts;
using Week_5_2.Entities;

Console.WriteLine("Postgre SQL");

ShopifyDbContext _context = new();

#region Add-Single

/*_context.Products.Add(new("BENGOO G9000 Stereo Gaming Headset for PS4 PC Xbox One PS5 Controller, Noise Cancelling Over Ear Headphones with Mic, LED Light, Bass Surround, Soft Memory Earmuffs for Laptop Mac Nintendo NES Games", 0.6m, 21.99m));
_context.SaveChanges();*/
#endregion

#region Add-Multiple

/*_context.Products.AddRange(new List<Product>
{
    new Product("Laptop", 2.5m, 1200.99m),
new Product("Smartphone", 0.2m, 800.50m),
new Product("Desk Chair", 15.0m, 150.75m),
new Product("Wireless Mouse", 0.1m, 25.49m),
new Product("Headphones", 0.3m, 50.00m),
new Product("Gaming Monitor", 4.5m, 299.99m),
new Product("Mechanical Keyboard", 1.2m, 130.50m),
new Product("Gaming PC", 12.0m, 1500.90m),
new Product("USB Flash Drive", 0.05m, 20.00m),
 new Product("Tablet", 0.6m, 299.49m),
 new Product("Wireless Charger", 0.3m, 35.00m),
 new Product("Bluetooth Speaker", 1.0m, 80.75m),
 new Product("Camera", 0.9m, 550.55m),
 new Product("Smart Watch", 0.1m, 249.99m),
 new Product("Hard Drive", 0.5m, 60.00m),
 new Product("E-Reader", 0.4m, 119.99m),
 new Product("Router", 0.8m, 75.50m),
 new Product("4K TV", 20.0m, 999.00m),
 new Product("Portable SSD", 0.2m, 110.00m)

});
_context.SaveChanges();*/
#endregion

#region Read-Multiple

/*foreach (Product product in _context.Products.Where(x => x.Weight > 1).OrderBy(x => x.Weight).ToList())
{
    Console.WriteLine(product);
}*/

#endregion

#region Read-Single

_context.Products.Where(x => x.Title.Contains("Smart")).ToList().ForEach(x => Console.WriteLine(x));
#endregion
