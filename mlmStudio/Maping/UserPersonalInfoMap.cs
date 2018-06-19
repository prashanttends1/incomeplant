using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace mlmStudio.Maping
{
    public class UserPersonalInfoMap : EntityTypeConfiguration<UserPersonalInfo> 
    {
        public UserPersonalInfoMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.FirstName).HasMaxLength(200);
             Property(o => o.LastName).HasMaxLength(200);
             HasRequired(c => c.Gender_GenderId).WithMany(o => o.UserPersonalInfo_GenderIds).HasForeignKey(o => o.GenderId).WillCascadeOnDelete(false);
             Property(o => o.About);
             Property(o => o.ProfileImage).HasMaxLength(200);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserPersonalInfo_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.MiddleName).HasMaxLength(200);
             Property(o => o.Email).HasMaxLength(33);
             Property(o => o.FatherAndSpouseName).HasMaxLength(100);
             Property(o => o.MotherName).HasMaxLength(100);
             Property(o => o.NomineName).HasMaxLength(100);
             HasRequired(c => c.City_CityId).WithMany(o => o.UserPersonalInfo_CityIds).HasForeignKey(o => o.CityId).WillCascadeOnDelete(false);
             Property(o => o.ZipCode).HasMaxLength(10);
             Property(o => o.PanNumber).HasMaxLength(50);
             Property(o => o.EducationDetail).HasMaxLength(500);
             Property(o => o.LastEmployeeFirm).HasMaxLength(100);
             Property(o => o.LastEmployeeYear).HasMaxLength(10);
             Property(o => o.LastEmployeeAnualIncome).HasMaxLength(100);
             ToTable("UserPersonalInfo");
 

        }
    }
}
