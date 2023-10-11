using System.ComponentModel.DataAnnotations.Schema; // StringLength
using System.ComponentModel.DataAnnotations;
public class Product
{
    public int ProductId { get; set; }
    [Required]
    [StringLength(40)]
    public string? ProductName { get; set; }
    [Column("UnitPrice", TypeName ="money")]
    public decimal? Cost { get; set; }
    public bool Discontinued { get; set; }
    [Column("UnitsInStock")]
    public short? Stock { get; set; }

    // Navigation properties
    public int CategoryId { get; set; }
    public virtual Category Categories { get; set; } = null!;
}