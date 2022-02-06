using System.Collections.Generic;

namespace MyProjectM.Models
{
    public class Theater
    {
     
        public int Id { get; set; }
        public string Place { get; set; }
        public int Capacity { get; set; }
        public ICollection<Ticket> tickets { get; set; }
    }
}
