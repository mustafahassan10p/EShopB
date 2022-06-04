using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopCoreBRazorApp.Data;
using EShopCoreBRazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EShopCoreBRazorApp.Pages.Product
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext db;
        public EditModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public Products? products { get; set; }
        public ActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();
            else
            {
                products = db.Product.Find(id);
                if (products == null)
                    return NotFound();
                else
                    return Page();
            }
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (products != null)
            {
                db.Attach(products).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToPage("./Index");
        }
    }
}
