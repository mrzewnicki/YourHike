using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using YourHike.Models.ViewModel;

namespace YourHike.Models.DTO
{

    public class HikeDTO
    {
        public HikeDTO()
        {
            
        }

        /*
        * Constructor allows mapping ViewModel on DataTransferObject 
        * to avoid repetition of code
        */
        public HikeDTO(HikeVM vModel)
        {
            Id = vModel.Id;
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
        public ICollection<FileDTO> Files { get; set; }
        public virtual ICollection<HistoryHikeVM> History { get; set; }
    }
}