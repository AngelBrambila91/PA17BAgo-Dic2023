using WorkingWithEFCore;

Northwind db = new();
WriteLine($"Provider : {db.Database.ProviderName}");

QueryingCategories();
QueryingProducts();
QueryingWithLike();
