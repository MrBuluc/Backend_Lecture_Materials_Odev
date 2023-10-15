using Productify.Domain.Extensions;

namespace Productify.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateOn { get; set; }

        public Product(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreateOn = DateTime.Now.SetKindUtc();
        }
    }
}
