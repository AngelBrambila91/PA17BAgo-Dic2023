using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking; // CollectionEntry
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
            IQueryable<Category>? categories;
            db.ChangeTracker.LazyLoadingEnabled = false;
            Write("Enable eager loading? (Y/N): ");
            bool eagerLoading = (ReadKey(intercept: true).Key == ConsoleKey.Y);
            bool explicitLoading = false;
            WriteLine();
            if(eagerLoading)
            {
                categories = db.Categories?.Include(c => c.Products);
            }
            else
            {
                categories = db.Categories;
                Write("Enable explicit loading? (Y/N): ");
                explicitLoading = (ReadKey(intercept:true).Key == ConsoleKey.Y);
                WriteLine();
            }


            foreach (Category category in categories!)
            {
                if(explicitLoading)
                {
                    Write($"Explicitly load products for {category.CategoryName} (Y/N): ");
                    ConsoleKeyInfo key = ReadKey(intercept: true);
                    WriteLine();
                    if(key.Key == ConsoleKey.Y)
                    {
                        CollectionEntry<Category, Product> products = 
                        db.Entry(category).Collection(category2 => category2.Products!);
                        if(!products.IsLoaded)
                        products.Load();
                    }
                }
                WriteLine($"{category.CategoryName} has {category.Products?.Count} products");
                Info($"Querying Products : {categories.ToQueryString()}");
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
                WriteLine($"{category.CategoryName} has {category.Products!.Count} products WITH a minimum of {stock}");
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
            .Where(p => EF.Functions.Like(p.ProductName!, $"%{input}%"));
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

    static void GetRandomProduct()
    {
        using(Northwind db = new())
        {
            SectionTitle("Get a Random product.");
            int? rowCount = db.Products?.Count();
            if(rowCount == null)
            {
                Fail("Products table is empty");
                return;
            }
            Product? p = 
            db.Products?.FirstOrDefault(
                p => p.ProductId == (int)
                (EF.Functions.Random() * rowCount));
            if(p == null)
            {
                Fail("Product not found");
                return;
            }
                WriteLine($"Random product: {p.ProductId} {p.ProductName}");
        }
    }
}