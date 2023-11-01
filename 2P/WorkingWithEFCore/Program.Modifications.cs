using System.Data.Common;
using System.Runtime.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkingWithEFCore;

partial class Program
{
    static void ListProducts(int []? productsIdToHighlight = null)
    {
        using (Northwind db  = new())
        {
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("{0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
            "Id", "Product Name", "Cost", "Stock", "Disc.");

            foreach (var product in db.Products)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((productsIdToHighlight is not null) && productsIdToHighlight.Contains(product.ProductId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{product.ProductId:000} | {product.ProductName,-35} | {product.Cost:#,##0.00,8} | {product.Stock,5} | {product.Discontinued}");
                ForegroundColor = backgroundColor;
            }
        }
    }

    // CRUD , Create, Read, Update, Delete
    static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price)
    {
        using (Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            Product p = new()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price,
                Stock = 72
            };
            
            EntityEntry<Product> entity = db.Products.Add(p);
            WriteLine($"State : {entity.State}, ProductId: {p.ProductId}");
            int affected = db.SaveChanges();
            WriteLine($"State : {entity.State}, ProductId: {p.ProductId}");

            return (affected, p.ProductId);
        }
    }

    // Update
    static (int affected, int productId) IncreaseProductPrice(string productNameStartsWith, decimal amount)
    {
        using (Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            // Get the first Product whose name starts with
            // productNameStartsWith
            Product updateProduct = db.Products.First(
                p => p.ProductName.StartsWith(productNameStartsWith)
            );
            updateProduct.Cost = amount;
            int affected = db.SaveChanges();
            return (affected, updateProduct.ProductId);
        }
    }

    // If you create the Update, you create the Delete basically
    static int DeleteProducts(string productsStartsWith)
    {
        using (Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?.Where(
                p => p.ProductName.StartsWith(productsStartsWith)
            );
            if((products is null) || (!products.Any()))
            {
                WriteLine("No products found to delete");
                return 0;
            }
            else
            {
                if (db.Products is null) return 0;
                db.Products.RemoveRange(products);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
}

