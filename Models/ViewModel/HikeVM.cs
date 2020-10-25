using System;
using System.ComponentModel.DataAnnotations;
using YourHike.Models.DTO;

namespace YourHike.Models.ViewModel
{
    public class HikeVM
    {
        public HikeVM(HikeDTO row)
        {
            Id = row.Id;
            Title = row.Title;
            StartDate = row.StartDate;
            EndDate = row.EndDate;
            StartPlace = row.StartPlace;
            EndPlace = row.EndPlace;
            Distance = row.Distance;
        }

        public int Id { get; set; }

        [Display(Name="Tytuł")]
        public string Title { get; set; }

        [Display(Name="Data rozpoczęcia:")]
        public DateTime StartDate { get; set; }

        [Display(Name="Data zakończenia:")]
        public DateTime? EndDate { get; set; }

        [Display(Name="Miejsce rozpoczęcia:")]
        public string StartPlace { get; set; }

        [Display(Name="Miejsce zakończenia:")]
        public string EndPlace { get; set; }

        [Display(Name="Dystans")]
        public double? Distance { get; set; }
    }
}