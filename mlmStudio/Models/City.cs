using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class City
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [StringLength(200)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [StringLength(15)] 
        [DisplayName("Latitude")] 
        public string Latitude { get; set; }
        [StringLength(15)] 
        [DisplayName("Longitude")] 
        public string Longitude { get; set; }
        [DisplayName("Is Active")] 
        public Nullable<bool> IsActive { get; set; }
        [Required]
        [DisplayName("State")] 
        public int? StateId { get; set; }
        public virtual State State_StateId { get; set; }
        public virtual ICollection<UserPersonalInfo> UserPersonalInfo_CityIds { get; set; }

    }
}
