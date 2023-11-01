using WorkingWithEFCore;

Northwind db = new();
WriteLine($"Provider : {db.Database.ProviderName}");

// QueryingCategories();
// QueryingProducts();
// QueryingWithLike();

// Using the add
ListProducts();
var resultAdd = AddProduct(categoryId: 6, productName:"La Pizza de Don Cangrejo", price:500M);
if(resultAdd.affected == 1)
{
    WriteLine($"Add product successful with ID : {resultAdd.productId}");
}
ListProducts(productsIdToHighlight: new int[] {resultAdd.productId});


// Using update
var resultUpdate = IncreaseProductPrice(productNameStartsWith: "La ", amount: 400.20M);
if(resultUpdate.affected == 1)
{
    WriteLine($"Increase price sucess for ID: {resultUpdate.productId}");
}
ListProducts(productsIdToHighlight: new int[] {resultUpdate.productId});


// Using delete
WriteLine("About to delete all products whose name starts with La ");
Write("Press Enter to continue or any other key");
if(ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProducts(productsStartsWith: "La ");
    WriteLine($"{deleted} products were deleted.");
}
else
{
    WriteLine("Delete was canceled");
}