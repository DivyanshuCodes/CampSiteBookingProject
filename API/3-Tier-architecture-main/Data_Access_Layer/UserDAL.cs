using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication6.Repository;

namespace Data_Access_Layer
{
    public class UserDAL
    {

        public void postUser(User user)
        {
            var db = new PersonDbContext();
            db.Add(user);
            db.SaveChanges();
        }

        public User userLogin(User user)
        {
            var db = new PersonDbContext();
            User u = new User();

            u = db.User.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            return u;
        }

    }
}
