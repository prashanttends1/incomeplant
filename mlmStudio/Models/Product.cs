using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class Product
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [Required]
        [DisplayName("Purchase Cost")] 
        public double PurchaseCost { get; set; }
        [DisplayName("Sale Price")] 
        public Nullable<double> SalePrice { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
        [DisplayName("Product Image")] 
        public string ProductImage { get; set; }
        [StringLength(50)] 
        [DisplayName("Bare Code")] 
        public string BareCode { get; set; }
        [DisplayName("Description")] 
        public string Description { get; set; }
        [StringLength(200)] 
        [DisplayName("Manufacturer")] 
        public string Manufacturer { get; set; }
        [Required]
        [DisplayName("Product Category")] 
        public int? ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory_ProductCategoryId { get; set; }

    }
}
