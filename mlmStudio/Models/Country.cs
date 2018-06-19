using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class Country
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [StringLength(3)] 
        [DisplayName("Code")] 
        public string Code { get; set; }
        [DisplayName("Is Active")] 
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<State> State_CountryIds { get; set; }

    }
}
