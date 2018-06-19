using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class ePinRequestMap : EntityTypeConfiguration<ePinRequest> 
    {
        public ePinRequestMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(200);
             HasRequired(c => c.User_FromUserId).WithMany(o => o.ePinRequest_FromUserIds).HasForeignKey(o => o.FromUserId).WillCascadeOnDelete(false);
             ToTable("ePinRequest");
 

        }
    }
}
