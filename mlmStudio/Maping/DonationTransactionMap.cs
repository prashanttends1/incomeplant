using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class DonationTransactionMap : EntityTypeConfiguration<DonationTransaction> 
    {
        public DonationTransactionMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.DonationRequest_DonationRequestId).WithMany(o => o.DonationTransaction_DonationRequestIds).HasForeignKey(o => o.DonationRequestId).WillCascadeOnDelete(false);
             HasRequired(c => c.Transaction_TransactionId).WithMany(o => o.DonationTransaction_TransactionIds).HasForeignKey(o => o.TransactionId).WillCascadeOnDelete(false);
             ToTable("DonationTransaction");
 

        }
    }
}
