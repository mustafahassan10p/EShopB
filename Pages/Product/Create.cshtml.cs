using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopCoreBRazorApp.Data;
using EShopCoreBRazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopCoreBRazorApp.Pages.Product
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext db;

        [BindProperty]
        public Products products { get; set; }

        public CreateModel(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (products != null)
            {
                db.Attach(products).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                db.SaveChanges();
                return RedirectToPage("./Index");
            }
            else
                return BadRequest();


        }
    }
}
