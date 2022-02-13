using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProjectM.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Include { get; set; }
        
        public string Film { get; set; }
        
        public int Numticket { get; set; }

        public string Members { get; set; }

        public string Theater { get; set; }
        public string User { get; set; }
        public int Total { get; set; }

    }
}
