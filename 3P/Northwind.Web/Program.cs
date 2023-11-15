using Common.Entities;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
// Adding decompression just because
builder.Services.AddRequestDecompression();
builder.Services.AddNorthwindContext();
var app = builder.Build();

// With this we configure the HTTP pipeline
if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

//To understand endpoints we can create the first example
// btw endpoints are /something , I.E. /hello/aloha
// /employees/getAll , etc
// with this function we can start understanding how the endpoints look like
app.Use(async (HttpContext context, Func<Task> next)
=> {
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
    if(rep is not null)
    {
        // This looks like this on the Terminal
        // Endpoint name : /Suppliers
        //Endpoint route pattern : Suppliers
        Console.WriteLine($"Endpoint name : {rep.DisplayName}");
        Console.WriteLine($"Endpoint route pattern : {rep.RoutePattern.RawText}");
    }
    if(context.Request.Path == "/bonjour")
    {
        // Let's say that i want to check for a specific EndPoint
        // in this case /bonjour, if that happens then we can delegate this thing
        // I hate french BTW :3 :B
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }
    // after the request, we can modify it as we please
    await next();
    // and we can modify the response, after the call of next()
});

app.UseRequestDecompression();
// To use endpoints we need the below one.
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();
app.MapGet("/hello", () => "Hello World!");

app.Run();

