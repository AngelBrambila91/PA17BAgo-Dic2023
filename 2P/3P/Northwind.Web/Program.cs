var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();
app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");


if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


app.Run();
