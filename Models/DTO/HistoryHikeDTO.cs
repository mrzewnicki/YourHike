using System;
using System.ComponentModel.DataAnnotations;
using YourHike.Models.ViewModel;

namespace YourHike.Models.DTO
{
    public class HistoryHikeDTO
    {
        public HistoryHikeDTO()
        {
            
        }

        /*
        * Constructor allows mapping ViewModel on DataTransferObject 
        * to avoid repetition of code
        */
        public HistoryHikeDTO(HistoryHikeVM vModel)
        {
            
        }

        [Key]
        public int Id { get; set; }
        public int HikeId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Description { get; set; }
        public DateTime ModifyTime { get; set; }

        public virtual HikeDTO Hike { get; set; }
    }
}