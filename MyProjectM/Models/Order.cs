using System.ComponentModel.DataAnnotations;

namespace MyProjectM.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Film { get; set; }
        [Required]
        public int Numticket { get; set; }
        [Required]
        public string member { get; set; }
        [Required]
        public string placeticket { get; set; }
        public string total { get; set; }
    }
}
