using Common.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
// TODO : ADD Extension Method?
 builder.Services.AddNorthwindContext();
var app = builder.Build();
app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");

if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


app.Run();
