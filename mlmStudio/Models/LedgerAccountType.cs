using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class LedgerAccountType
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual LedgerAccountType LedgerAccountType2 { get; set; }
        public virtual ICollection<LedgerAccount> LedgerAccount_LedgerAccountTypeIds { get; set; }
        public virtual ICollection<LedgerAccountType> LedgerAccountType_ParentIds { get; set; }

    }
}
