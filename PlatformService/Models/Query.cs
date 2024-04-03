using PlatformService.Models;

public class Query
{
    public Product GetProduct()
    {
        return new Product
        {
            Id = "1",
            Name = "Sách cấmm",
            CategoryName = "Book",
            Price = 1000,
            Description = "Rất hay"
        };
    }

    public string Hello(string name = "World") => $"Hello, {name}";

    public object GetAllProducts()
    {
        return new Product { Id = "2" };
    }
};
