using Microsoft.EntityFrameworkCore;

using WorkingWithEFCore;

partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            // SELECT * FROM Categories AS C
            // LEFT JOIN Products AS P ON P.CategoryId = C.CategoryId
            SectionTitle("Categories and how many products they have: ");
            // IQueryable
            IQueryable<Category>? categories =
            db.Categories?
            .Include(c => c.Products);
            if ((categories is null) || !categories.Any())
            {
                Fail("No categories Found");
                return;
            }
            // Iterate trough categories
            foreach (Category category in categories)
            {
                WriteLine($"{category.CategoryName} has {category.Products!.Count} products.");
                Info($"Querying Categories : {categories.ToQueryString()}");
            }
        }

    }

    static void FilteredInclude()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products with a MINIMUM of units in stock.");
            string? input;
            int stock;
            do
            {
                Write("Enter a minimum dfor units in STOCK: ");
                input = ReadLine();
            } while (!int.TryParse(input, out stock));

            // SELECT * FROM Categories AS C
            // LEFT JOIN PRODUCTS AS P ON P.CategoryId = C.CategoryId
            // WHERE P.Stock >= @Stock
            IQueryable<Category>? categories =
            db.Categories?
            .Include(c => c.Products!.Where(p => p.Stock >= stock));
            if ((categories is null) || !categories.Any())
            {
                Fail("No categories found");
                return;
            }
            foreach (Category category in categories)
            {
                WriteLine($"{category.CategoryName} has {category.Products.Count} products WITH a minimum of {stock}");
                foreach (Product product in category.Products)
                {
                    WriteLine($"{product.ProductName} has {product.Stock} units in Stock");
                }
            }
        }
    }

    static void QueryingProducts()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products that cost more than a price, highest at top");
            string? input;
            int price;
            do
            {
                Write("Enter a minimum dfor units in STOCK: ");
                input = ReadLine();
            } while (!int.TryParse(input, out price));
            IQueryable<Product>? products =
            db.Products?
            .Where(product => product.Cost > price)
            .OrderByDescending(product => product.Cost);
            if ((products is null) || !products.Any())
            {
                Fail("No products found");
                return;
            }
            foreach (Product product in products)
            {
                WriteLine($"{product.ProductId} : {product.ProductName} costs {product.Cost: $#,##0.00} and has {product.Stock} in stock");
                Info($"Querying Products : {products.ToQueryString()}");
            }
        }
    }
    static void QueryingWithLike()
    {
        using (Northwind db = new())
        {
            SectionTitle("Pattern Matching with Like");
            Write("Enter a part of a product name: ");
            string? input = ReadLine();
            if ((string.IsNullOrWhiteSpace(input)))
            {
                Fail("You did not enter part of a product");
                return;
            }
            // %input%
            IQueryable<Product>? products =
            db.Products?
            .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
            if ((products is null) || !products.Any())
            {
                Fail("No products found");
                return;
            }
            foreach (Product product in products)
            {
                WriteLine($"{product.ProductName} , has {product.Stock} units in stock. Discontinued? {product.Discontinued}");
                //Info($"Querying Products with Like : {products.ToQueryString()}");
            }
        }
    }
}