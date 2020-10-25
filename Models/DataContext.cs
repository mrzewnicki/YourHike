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
        }
        
    }
}