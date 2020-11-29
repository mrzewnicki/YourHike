using System;
using System.ComponentModel.DataAnnotations;
using YourHike.Models.DTO;


namespace YourHike.Models.ViewModel
{
    public class FileVM
    {
        public FileVM()
        {
            
        }

        public FileVM(FileDTO row)
        {
            Id = row.Id;
            DisplayName = row.DisplayName;
            FileType = row.DisplayName;
            FileName = row.FileName;
            UploadTime = row.UploadTime;
            HikeId = row.HikeId;
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public DateTime UploadTime { get; set; }
        public int HikeId { get; set; }
        public virtual HikeVM Hike{ get; set; }
    }
}