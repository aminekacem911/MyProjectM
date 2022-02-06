using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using MyProjectM.Models;

namespace MyProjectM.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MyProjectMUser class
    public class MyProjectMUser : IdentityUser
    {
       

        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Isadmin { get; set; }

     

    }
}
