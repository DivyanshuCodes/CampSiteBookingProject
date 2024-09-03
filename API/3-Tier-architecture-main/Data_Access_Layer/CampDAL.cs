using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication6.Repository;
using WebApplication6.Repository.Entities;


namespace Data_Access_Layer
{
    public class CampDAL
    {
        public void postCamp(Camp camp)
        {
            var db = new PersonDbContext();
            db.Add(camp);
            db.SaveChanges();
        }
        public List<Camp> getCamp()
        {
            var db = new PersonDbContext();
            return db.Camp.ToList();
        }
        public void deleteCamp(Camp campObj)
        {
            var db = new PersonDbContext();
            Camp c = new Camp();
            c = db.Camp.FirstOrDefault(x => x.CampId == campObj.CampId);
            if (c == null)
                throw new Exception("Not found");

            db.Camp.Remove(c);
            db.SaveChanges();
        }
        public Camp GetCampById(Camp camp)
        {
            var db = new PersonDbContext();
            Camp c = new Camp();

            c = db.Camp.FirstOrDefault(x => x.CampId == camp.CampId);

            return c;
        }
        //public Camp GetCampById(String campId)
        //{
        //    var db = new PersonDbContext();
        //    Camp c = new Camp();

        //    c = db.Camp.FirstOrDefault(x => x.CampId == campId);

        //    return c;
        //}
        public List<Camp> filterCamp(Camp camp)
        {
            Camp c = new Camp();
            var db = new PersonDbContext();
            List<Camp> camps = new List<Camp>();
            camps.Add(db.Camp.FirstOrDefault(x => x.Capacity == camp.Capacity));
            return camps;
        }

    }
}
