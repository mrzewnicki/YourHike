using System;
using Microsoft.EntityFrameworkCore;
using YourHike.Models.DTO;

namespace YourHike.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<HikeDTO> Hikes { get; set; }
        public DbSet<FileDTO> Files { get; set; }
        public DbSet<HistoryHikeDTO> HikesHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HikeDTO>().HasData(
                new HikeDTO{
                    Id=1,
                    Title="Las Kabacki",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    StartPlace = "Dom",
                    EndPlace = "Las Kabacki",
                    Distance = 5.4
                },
                new HikeDTO{
                    Id=2,
                    Title="Chojnowski Park Krajobrazowy",
                    StartDate = DateTime.Now.AddDays(5),
                    EndDate = DateTime.Now.AddDays(5),
                    StartPlace = "Dom",
                    EndPlace = "Chojnowski Park Krajobrazowy",
                    Distance = 9.2
                }
                );

                builder.Entity<FileDTO>().HasData(
                new FileDTO{
                    Id = 1,
                    DisplayName="Zdjęcie pierwsze",
                    FileType = "png",
                    FileName = "pierwsze_zdjecie.png",
                    UploadTime = DateTime.Now,
                    HikeId = 1
                },
                new FileDTO{
                    Id = 2,
                    DisplayName="Zdjęcie drugie",
                    FileType = "png",
                    FileName = "drugie_zdjecie.png",
                    UploadTime = DateTime.Now,
                    HikeId = 1
                },
                new FileDTO{
                    Id = 3,
                    DisplayName="Zdjęcie trzecie",
                    FileType = "png",
                    FileName = "trzecie_zdjecie.png",
                    UploadTime = DateTime.Now,
                    HikeId = 2
                }
            );

            builder.Entity<HistoryHikeDTO>().HasData(
                new HistoryHikeDTO{
                    Id = 1,
                    HikeId = 1,
                    OldValue = "Chojnowski",
                    NewValue = "Chojnowski Park Krajobrazowy",
                    Description = "Zmiana tytułu",
                    ModifyTime = DateTime.Now
                }
            );
        }
        
    }
}