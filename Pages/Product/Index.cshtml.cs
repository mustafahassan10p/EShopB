using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EShopCoreBRazorApp.Model;
using EShopCoreBRazorApp.Data;

namespace EShopCoreBRazorApp.Pages.Product
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext db;

        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IList<Products> Products { get; set; }
        public void OnGet()
        {
            Products = db.Product.Select(x => x).OrderBy(x => x.ProductName).ToList();
        }

        public ActionResult OnPostDelete(int? id)
        {
            if (id == null)
                return NotFound();
            else
            {
                var products = db.Product.Find(id);
                if (products == null)
                    return NotFound();
                else
                {
                    db.Product.Remove(products);
                    db.SaveChanges();
                    return RedirectToPage();
                }
            }
        }
    }
}
