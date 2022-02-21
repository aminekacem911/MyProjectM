
using MyProjectM.Areas.Identity.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProjectM.Models
{
    public class Member
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string User { get; set; }
        
    }

}
