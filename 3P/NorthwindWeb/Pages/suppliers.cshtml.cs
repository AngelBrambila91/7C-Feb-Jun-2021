using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        [BindProperty]
        public Supplier Supplier {get; set;}
        public IEnumerable<string> Suppliers { get; set; }
        private Northwind db;
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Website - Suppliers";
            Suppliers = db.Suppliers.Select(s => s.CompanyName);
        }

        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }

    }
}