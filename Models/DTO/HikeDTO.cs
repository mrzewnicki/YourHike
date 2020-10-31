using System;
using System.ComponentModel.DataAnnotations;
using YourHike.Models.ViewModel;

namespace YourHike.Models.DTO
{
    public class HikeDTO
    {
        public HikeDTO()
        {
            
        }
        public HikeDTO(HikeVM vModel)
        {
            Title = vModel.Title;
            StartDate = vModel.StartDate;
            EndDate = vModel.EndDate;
            StartPlace = vModel.StartPlace;
            EndPlace = vModel.EndPlace;
            Distance = vModel.Distance;
        }

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