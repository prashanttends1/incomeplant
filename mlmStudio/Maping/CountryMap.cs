using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class CountryMap : EntityTypeConfiguration<Country> 
    {
        public CountryMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(200);
             Property(o => o.Code).HasMaxLength(3);
             ToTable("Country");
 

        }
    }
}
