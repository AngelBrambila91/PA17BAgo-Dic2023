using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc; // IActionResult

using Common.Entities;
namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
    private NorthwindContext db;
    public SuppliersModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }
    [BindProperty]
    public Supplier? Supplier { get; set; }
    public IEnumerable<Supplier>? Suppliers { get; set; }
    public void OnGet()
    {
        ViewData["Title"] = "Northwind - Suppliers";
        Suppliers = db.Suppliers.OrderBy(s => s.Country).ThenBy(s => s.CompanyName);
    }
    public IActionResult OnPost()
    {
        if((Supplier is not null) && ModelState.IsValid)
        {
            db.Suppliers.Add(Supplier);
            db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        else
        {
            return Page();
        }
    }
}