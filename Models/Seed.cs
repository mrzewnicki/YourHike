using System;
using System.Collections.Generic;
using System.Linq;
using YourHike.Models.DTO;

namespace YourHike.Models
{
    public class Seed
    {
        public static void SeedData(DataContext db)
        {
            if(!db.Hikes.Any())
            {
                var travels = new List<HikeDTO>{
                    new HikeDTO{
                        Title="Orla Perć",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(1),
                        StartPlace = "Zawrat",
                        EndPlace = "Krzyżne",
                        Distance = 4.5
                    },
                    new HikeDTO{
                        Title="Dolina Pięciu Stawów Polskich",
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(5),
                        StartPlace = "Morskie Oko",
                        EndPlace = "Dolina Pięciu Stawów",
                        Distance = 5.2
                    },
                    new HikeDTO{
                        Title="Czarny Staw Polski",
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(5),
                        StartPlace = "Dolina Pięciu Stawów Polskich",
                        EndPlace = "Czarny Staw Polski",
                        Distance = 1.2
                    }
                };

                db.Hikes.AddRange(travels);
                db.SaveChanges();
            }
        }
    }
}