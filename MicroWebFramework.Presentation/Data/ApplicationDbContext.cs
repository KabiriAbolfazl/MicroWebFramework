using MicroWebFramework.Presentation.Models;

namespace MicroWebFramework.Presentation.Data;
public class ApplicationDbContext
{
    public IEnumerable<Product> Products { get; }
    public IEnumerable<User> Users { get; }
    public ApplicationDbContext()
    {
        Products = new List<Product>()
            {
                new Product {Id = 1, Name = "Samsung", Price = 1000 },
                new Product { Id = 2, Name = "Apple", Price = 2000 }
            };
        Users = new List<User>()
            {
                new User {Id = 1, Name = "Ali" },
                new User {Id = 2, Name = "Abolfazl" }
            };
    }
}
