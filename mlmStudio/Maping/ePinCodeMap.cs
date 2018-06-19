using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class ePinCodeMap : EntityTypeConfiguration<ePinCode> 
    {
        public ePinCodeMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.ePinRequest_ePinRequestId).WithMany(o => o.ePinCode_ePinRequestIds).HasForeignKey(o => o.ePinRequestId).WillCascadeOnDelete(false);
             Property(o => o.PCode).HasMaxLength(35);
             ToTable("ePinCode");
 

        }
    }
}
