using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class CityMap : EntityTypeConfiguration<City> 
    {
        public CityMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(200);
             Property(o => o.Latitude).HasMaxLength(15);
             Property(o => o.Longitude).HasMaxLength(15);
             HasRequired(c => c.State_StateId).WithMany(o => o.City_StateIds).HasForeignKey(o => o.StateId).WillCascadeOnDelete(false);
             ToTable("City");
 

        }
    }
}
