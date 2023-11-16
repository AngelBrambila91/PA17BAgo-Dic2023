using System.Reflection;
using Common.Entities;

namespace Northwind.Mvc.Models;
// simple way to use a ViewModel
public record HomeIndexViewModel
(
    int VisitorCount,
    IList<Category> Categories,
    IList<Product> Products
);