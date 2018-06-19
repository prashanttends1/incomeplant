using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class InvoiceTransactionMap : EntityTypeConfiguration<InvoiceTransaction> 
    {
        public InvoiceTransactionMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Invoice_InvoiceId).WithMany(o => o.InvoiceTransaction_InvoiceIds).HasForeignKey(o => o.InvoiceId).WillCascadeOnDelete(false);
             ToTable("InvoiceTransaction");
 

        }
    }
}
