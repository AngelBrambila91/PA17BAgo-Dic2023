using System.ComponentModel.DataAnnotations.Schema; // Column, Atrributes
public class Category
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
    // Navigation Property
    // Collection that holds the result of the relation between two tables
    // IN THIS CASE, the relation between Categories and Products
    public virtual ICollection<Product>? Products { get; set; }

    public Category()
    {
        Products = new HashSet<Product>();
    }
}