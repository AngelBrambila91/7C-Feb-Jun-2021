using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<string> Suppliers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Nothwind Website - Suppliers";
            Suppliers = new [] {
                "Dunder Mifflin", "Staples", "OfficeMax"
            };
        }
    }
}