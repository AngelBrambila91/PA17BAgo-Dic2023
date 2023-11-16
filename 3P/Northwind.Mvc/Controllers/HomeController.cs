using System.Diagnostics;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
// Always remmeber to add the namespace of the entities
using Common.Entities;

namespace Northwind.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // For dependency Injection
    private readonly NorthwindContext db;

    public HomeController(ILogger<HomeController> logger, NorthwindContext injectedContext)
    {
        _logger = logger;
        // Classic dependency Injection, we used it on the Empty Web poroject too
        db = injectedContext;
    }

    public IActionResult Index()
    {
        // Using the _logger to show some use of it. Chek on terminal.
        _logger.LogError("This is a serious error (not really)");
        _logger.LogWarning("This is your first warning!");
        _logger.LogWarning("Second Warning!!!");
        _logger.LogInformation("I am in the Index method of the HomeController");

        // Create an instance for HomeIndexViewModel
        HomeIndexViewModel model = new
        (
            // Do something with the model that we create
            VisitorCount: Random.Shared.Next(1, 1001),
            Categories: db.Categories.ToList(),
            Products: db.Products.ToList()
        );
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
