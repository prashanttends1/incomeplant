using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class State
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [StringLength(5)] 
        [DisplayName("Code")] 
        public string Code { get; set; }
        [DisplayName("Is Active")] 
        public Nullable<bool> IsActive { get; set; }
        [Required]
        [DisplayName("Country")] 
        public int? CountryId { get; set; }
        public virtual Country Country_CountryId { get; set; }
        public virtual ICollection<City> City_StateIds { get; set; }

    }
}
