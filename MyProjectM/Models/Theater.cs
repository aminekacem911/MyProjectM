namespace MyProjectM.Models
{
    public class Theater
    {
        [Key]
        public int Id { get; set; }
        public string Place { get; set; }
        public int Capacity { get; set; }
    }
}
