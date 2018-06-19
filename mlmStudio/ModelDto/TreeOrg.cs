using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mlmStudio.ModelDto
{
   
    public class TreeOrg
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Leg { get; set; }
        public int ParentId { get; set; }
        public bool IsActive { get; set; }
    }
    
    
}