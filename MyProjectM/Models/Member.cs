
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProjectM.Models
{
    public class Member
    {
        //public Member()
        //{
        //    MyProjectMUser = new HashSet<MyProjectMUser>();
        //}
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
      

    }

}
