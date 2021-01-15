using System;
using System.ComponentModel.DataAnnotations;
using YourHike.Models.DTO;

namespace YourHike.Models.ViewModel
{
    public class HistoryHikeVM
    {
        public HistoryHikeVM()
        {
            
        }

        public HistoryHikeVM(HistoryHikeDTO row)
        {
            Id = row.Id;
            HikeId = row.HikeId;
            OldValue = row.OldValue;
            NewValue = row.NewValue;
            Description = row.Description;
            ModifyTime = row.ModifyTime;

            if (row.Hike != null)
            {
                Hike = new HikeVM(row.Hike);
            }
        }

        public int Id { get; set; }
        public int HikeId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Description { get; set; }
        public DateTime ModifyTime { get; set; }
        public virtual HikeVM Hike { get; set; }
    }
}