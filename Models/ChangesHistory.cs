using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using YourHike.Models.DTO;
using YourHike.Models.ViewModel;

namespace YourHike.Models
{
    public class History
    {
        private DataContext _db;
        public History(DataContext db)
        {
            _db = db;
        }

        public void Update(HikeVM toUpdate)
        {
            if (toUpdate.Id == null || toUpdate.Id == 0)
            {
                return;
            }

            HikeDTO travel = _db.Hikes.Find(toUpdate.Id);

            if (toUpdate.Title != travel.Title)
            {
                Attribute lblAttr = toUpdate.Title.GetType().IsDefined(typeof(DisplayAttribute))? toUpdate.Title.GetType().GetCustomAttribute(typeof(DisplayAttribute)): null;

                string fieldLbl = toUpdate.GetType().GetProperty("Title").Name;

                if (lblAttr != null)
                {
                    fieldLbl = lblAttr.GetType().GetProperty("Name").GetValue(lblAttr).ToString();
                }

                _db.HikesHistory.Add(new HistoryHikeDTO()
                {
                    HikeId = travel.Id,
                    ModifyTime = DateTime.Now,
                    OldValue = travel.Title,
                    NewValue = toUpdate.Title,
                    Description = "Modyfikacja pola "+ fieldLbl
                });

                travel.Title = toUpdate.Title;
            }

            if (toUpdate.StartDate != travel.StartDate)
            {
                Attribute lblAttr = toUpdate.StartDate.GetType().IsDefined(typeof(DisplayAttribute)) ? toUpdate.StartDate.GetType().GetCustomAttribute(typeof(DisplayAttribute)) : null;

                string fieldLbl = toUpdate.GetType().GetProperty("StartDate").Name;

                if (lblAttr != null)
                {
                    fieldLbl = lblAttr.GetType().GetProperty("Name").GetValue(lblAttr).ToString();
                }

                _db.HikesHistory.Add(new HistoryHikeDTO()
                {
                    HikeId = travel.Id,
                    ModifyTime = DateTime.Now,
                    OldValue = travel.StartDate.ToString(),
                    NewValue = toUpdate.StartDate.ToString(),
                    Description = "Modyfikacja pola " + fieldLbl
                });

                travel.StartDate = toUpdate.StartDate;
            }

            if (toUpdate.EndDate != travel.EndDate)
            {
                Attribute lblAttr = toUpdate.EndDate.GetType().IsDefined(typeof(DisplayAttribute)) ? toUpdate.EndDate.GetType().GetCustomAttribute(typeof(DisplayAttribute)) : null;

                string fieldLbl = toUpdate.GetType().GetProperty("EndDate").Name;

                if (lblAttr != null)
                {
                    fieldLbl = lblAttr.GetType().GetProperty("Name").GetValue(lblAttr).ToString();
                }

                _db.HikesHistory.Add(new HistoryHikeDTO()
                {
                    HikeId = travel.Id,
                    ModifyTime = DateTime.Now,
                    OldValue = travel.EndDate.ToString(),
                    NewValue = toUpdate.EndDate.ToString(),
                    Description = "Modyfikacja pola " + fieldLbl
                });

                travel.EndDate = toUpdate.EndDate;
            }

            if (toUpdate.StartPlace != travel.StartPlace)
            {
                Attribute lblAttr = toUpdate.StartPlace.GetType().IsDefined(typeof(DisplayAttribute)) ? toUpdate.StartPlace.GetType().GetCustomAttribute(typeof(DisplayAttribute)) : null;

                string fieldLbl = toUpdate.GetType().GetProperty("StartPlace").Name;

                if (lblAttr != null)
                {
                    fieldLbl = lblAttr.GetType().GetProperty("Name").GetValue(lblAttr).ToString();
                }

                _db.HikesHistory.Add(new HistoryHikeDTO()
                {
                    HikeId = travel.Id,
                    ModifyTime = DateTime.Now,
                    OldValue = travel.StartPlace,
                    NewValue = toUpdate.StartPlace,
                    Description = "Modyfikacja pola " + fieldLbl
                });

                travel.StartPlace = toUpdate.StartPlace;
            }

            if (toUpdate.EndPlace != travel.EndPlace)
            {
                Attribute lblAttr = toUpdate.EndPlace.GetType().IsDefined(typeof(DisplayAttribute)) ? toUpdate.EndPlace.GetType().GetCustomAttribute(typeof(DisplayAttribute)) : null;

                string fieldLbl = toUpdate.GetType().GetProperty("EndPlace").Name;

                if (lblAttr != null)
                {
                    fieldLbl = lblAttr.GetType().GetProperty("Name").GetValue(lblAttr).ToString();
                }

                _db.HikesHistory.Add(new HistoryHikeDTO()
                {
                    HikeId = travel.Id,
                    ModifyTime = DateTime.Now,
                    OldValue = travel.EndPlace,
                    NewValue = toUpdate.EndPlace,
                    Description = "Modyfikacja pola " + fieldLbl
                });

                travel.EndPlace = toUpdate.EndPlace;
            }

            if (toUpdate.Distance != travel.Distance)
            {
                Attribute lblAttr = toUpdate.Distance.GetType().IsDefined(typeof(DisplayAttribute)) ? toUpdate.Distance.GetType().GetCustomAttribute(typeof(DisplayAttribute)) : null;

                string fieldLbl = toUpdate.GetType().GetProperty("Distance").Name;

                if (lblAttr != null)
                {
                    fieldLbl = lblAttr.GetType().GetProperty("Name").GetValue(lblAttr).ToString();
                }

                _db.HikesHistory.Add(new HistoryHikeDTO()
                {
                    HikeId = travel.Id,
                    ModifyTime = DateTime.Now,
                    OldValue = travel.Distance.ToString(),
                    NewValue = toUpdate.Distance.ToString(),
                    Description = "Modyfikacja pola " + fieldLbl
                });

                travel.Distance = toUpdate.Distance;
            }

            _db.Update(travel);
            _db.SaveChanges();
        }

    }
}
