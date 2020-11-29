using System;
using System.ComponentModel.DataAnnotations;
using YourHike.Models.ViewModel;

namespace YourHike.Models.DTO
{
    public class FileDTO
    {
        public FileDTO()
        {
            
        }
        
        /*
        * Constructor allows mapping ViewModel on DataTransferObject 
        * to avoid repetition of code
        */
        public FileDTO(FileVM vModel)
        {
            Id = vModel.Id;
            DisplayName = vModel.DisplayName;
            FileType = vModel.DisplayName;
            FileName = vModel.FileName;
            UploadTime = vModel.UploadTime;
            HikeId = vModel.HikeId;
        }

        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public DateTime UploadTime { get; set; }
        public int HikeId { get; set; }
        public virtual HikeDTO Hike{ get; set; }
    }
}