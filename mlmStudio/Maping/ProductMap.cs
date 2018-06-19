using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class ProductMap : EntityTypeConfiguration<Product> 
    {
        public ProductMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(100);
             Property(o => o.ProductImage).HasMaxLength(200);
             Property(o => o.BareCode).HasMaxLength(50);
             Property(o => o.Description);
             Property(o => o.Manufacturer).HasMaxLength(200);
             HasRequired(c => c.ProductCategory_ProductCategoryId).WithMany(o => o.Product_ProductCategoryIds).HasForeignKey(o => o.ProductCategoryId).WillCascadeOnDelete(false);
             ToTable("Product");
 

        }
    }
}
