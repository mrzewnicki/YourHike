using System;
using System.ComponentModel.DataAnnotations;

namespace YourHike.Models.DTO
{
    public class HikeDTO
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
        public double? Distance { get; set; }
    }
}