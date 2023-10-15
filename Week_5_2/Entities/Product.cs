namespace Week_5_2.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            
        }

        public Product(string title, decimal weight, decimal price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Weight = weight;
            Price = price;
        }

        public override string? ToString() => $"Product(Id={Id}, Title={Title}, Weight={Weight}, Price={Price})";
    }
}
