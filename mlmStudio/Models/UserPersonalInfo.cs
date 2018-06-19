using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mlmStudio.Models
{
    public class UserPersonalInfo
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("First Name")] 
        public string FirstName { get; set; }
        [StringLength(200)] 
        [DisplayName("Last Name")] 
        public string LastName { get; set; }
        [Required]
        [DisplayName("Gender")] 
        public int? GenderId { get; set; }
        public virtual Gender Gender_GenderId { get; set; }
        [DisplayName("About")] 
        public string About { get; set; }
        [DisplayName("Profile Image")] 
        public string ProfileImage { get; set; }
        [Required]
        [DisplayName("Date Join")] 
        public DateTime DateJoin { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [StringLength(200)] 
        [DisplayName("Middle Name")] 
        public string MiddleName { get; set; }
[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]        [StringLength(33)] 
        [DisplayName("Email")] 

        public string Email { get; set; }
        [StringLength(100)] 
        [DisplayName("Father And Spouse Name")] 
        public string FatherAndSpouseName { get; set; }
        [DisplayName("D O B")] 
        public Nullable<DateTime> DOB { get; set; }
        [StringLength(100)] 
        [DisplayName("Mother Name")] 
        public string MotherName { get; set; }
        [StringLength(100)] 
        [DisplayName("Nomine Name")] 
        public string NomineName { get; set; }
        [Required]
        [DisplayName("City")] 
        public int? CityId { get; set; }
        public virtual City City_CityId { get; set; }
        [StringLength(10)] 
        [DisplayName("Zip Code")] 
        public string ZipCode { get; set; }
        [StringLength(50)] 
        [DisplayName("Pan Number")] 
        public string PanNumber { get; set; }
        [DisplayName("Education Detail")] 
        public string EducationDetail { get; set; }
        [StringLength(100)] 
        [DisplayName("Last Employee Firm")] 
        public string LastEmployeeFirm { get; set; }
        [StringLength(10)] 
        [DisplayName("Last Employee Year")] 
        public string LastEmployeeYear { get; set; }
        [StringLength(100)] 
        [DisplayName("Last Employee Anual Income")] 
        public string LastEmployeeAnualIncome { get; set; }
        [DisplayName("Is Active")] 
        public Nullable<bool> IsActive { get; set; }

    }
}
