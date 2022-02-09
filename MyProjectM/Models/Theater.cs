using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProjectM.Models
{
    public class Theater
    {
     
        public int TheaterID { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
