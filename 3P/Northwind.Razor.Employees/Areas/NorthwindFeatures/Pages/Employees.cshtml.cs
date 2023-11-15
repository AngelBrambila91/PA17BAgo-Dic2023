using Microsoft.AspNetCore.Mvc.RazorPages;
using Common.Entities;
namespace NorthwindFeatures.Pages;

public class EmployeesPageModel : PageModel
{
    private NorthwindContext? db;
    public EmployeesPageModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }
    public Employee?[] Employees { get; set; }

    // On Get always get called when you open the page, obviously this is not
    // really efficient at all, but we're progressing
    public void OnGet()
    {
        ViewData["Title"] = "Northwind Web Shit - Employees";
        Employees = db.Employees.OrderBy(e => e.LastName)
        .ThenBy(e => e.FirstName).ToArray();
    }
}