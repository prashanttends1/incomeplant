using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class StateMap : EntityTypeConfiguration<State> 
    {
        public StateMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(200);
             Property(o => o.Code).HasMaxLength(5);
             HasRequired(c => c.Country_CountryId).WithMany(o => o.State_CountryIds).HasForeignKey(o => o.CountryId).WillCascadeOnDelete(false);
             ToTable("State");
 

        }
    }
}
