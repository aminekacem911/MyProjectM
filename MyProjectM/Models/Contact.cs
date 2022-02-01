using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace MyProjectM.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nom Obligatoire")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Subject Obligatoire")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Message Obligatoire")]
        [Column(TypeName = "nvarchar(1000)")]

        public string Message { get; set; }
        [Required(ErrorMessage = "Email Obligatoire")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }


    }
}
