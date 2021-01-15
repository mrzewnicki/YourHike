using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using YourHike.Models.DTO;

namespace YourHike.Models.ViewModel
{
    public class HikeVM
    {
        public HikeVM()
        {
            
        }

        public HikeVM(HikeDTO row)
        {
            Id = row.Id;
            Title = row.Title;
            StartDate = row.StartDate;
            EndDate = row.EndDate;
            StartPlace = row.StartPlace;
            EndPlace = row.EndPlace;
            Distance = row.Distance;

            this.Files = new List<FileVM>();
            if (row.Files!=null && row.Files.Any())
            {
                foreach (FileDTO fileDto in row.Files)
                {
                    this.Files.Add(new FileVM(fileDto));
                }
            }

            History = new List<HistoryHikeVM>();
        }

        public int Id { get; set; }

        [Display(Name="Tytuł")]
        [Required]
        public string Title { get; set; }

        [Display(Name="Data rozpoczęcia:")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name="Data zakończenia:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name="Miejsce rozpoczęcia:")]
        [Required]
        public string StartPlace { get; set; }

        [Display(Name="Miejsce zakończenia:")]
        public string EndPlace { get; set; }

        [Display(Name="Dystans")]
        public double? Distance { get; set; }

        [Display(Name="Pliki")]
        public List<FileVM> Files { get; set; }
        [Display(Name = "Historia zmian")]
        public List<HistoryHikeVM> History { get; set; }
    }
}