using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCoreBRazorApp.Model
{
    public class Products
    {
        [Key]
        [DisplayName("ID")]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Product Quantity")]
        [Required]
        public int Qty { get; set; }

        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }

        [DisplayName("Created Date")]
        [Required]
        public DateTime CreatedDateTime { get; set; }

        public Category category { get; set; }
    }
}
