using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication6.Repository;

namespace Data_Access_Layer
{
    public class RatingDAL
    {
        public void addRating(Rating rating)
        {
            var db = new PersonDbContext();
            Rating r = new Rating();
            r = db.Rating.FirstOrDefault(x => x.CampId == rating.CampId);
            if(r==null)
            {
                rating.NumberRating = 1;
                rating.AverageRating = rating.TotalRating;
                db.Add(rating);
                db.SaveChanges();
            }
            else
            {
                r.TotalRating =(r.TotalRating+rating.TotalRating);
                r.NumberRating = (r.NumberRating + 1);
                r.AverageRating = (r.TotalRating / r.NumberRating);
                db.SaveChanges();
            }
        }
    }
}
