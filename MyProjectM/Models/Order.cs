﻿namespace MyProjectM.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Numticket { get; set; }
        public string placeticket { get; set; }
        public string total { get; set; }
    }
}
