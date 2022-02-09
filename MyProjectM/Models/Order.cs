using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProjectM.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Include { get; set; }
        
        public string Film { get; set; }
        
        public string Numticket { get; set; }

        public string Members { get; set; }
        //public List<string> Members { set; get; }
       // public int[] SelectedMember { set; get; }

        public string Theater { get; set; }
        public string User { get; set; }
        
    }
}
