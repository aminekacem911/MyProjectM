using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProjectM.Models
{
    public class Ticket

    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]

        public string Price { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]

        public string Stock { get; set; }

    }
}
