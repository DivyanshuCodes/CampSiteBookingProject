using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication6.Repository;

namespace Data_Access_Layer
{
    public class BookingDAL
    {
        public void addBooking(Booking bookObj)
        {
            var db = new PersonDbContext();
            db.Add(bookObj);
            db.SaveChanges();
        }
        public Camp findBooking(string bookObj)
        {
            var db = new PersonDbContext();
            Booking newBook= db.Booking.FirstOrDefault(x => x.ReferenceNo == bookObj);
            if (newBook != null)
            {
                Camp camp = db.Camp.FirstOrDefault(x => x.CampId == newBook.CampId);
                return camp;
            }
            else
            {
                return null;
            }
        }
        public void deleteBooking(string referenceNo)
        {
            var db = new PersonDbContext();
            Booking newBook = db.Booking.FirstOrDefault(x => x.ReferenceNo == referenceNo);
            if (referenceNo != null)
            {
                db.Booking.Remove(newBook);
                db.SaveChanges();
            }
            else
            {
            }
        }
    }
}
