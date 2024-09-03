using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication6.Repository;
using WebApplication6.Repository.Entities;


namespace Data_Access_Layer
{
    public class PersonDAL
    {
        public List<Person> GetAllPersons()
        {
            var db = new PersonDbContext();
            return db.Person.ToList();
        }

        public Person GetPersonById(int id)
        {
            var db = new PersonDbContext();
            Person p = new Person();

            p = db.Person.FirstOrDefault(x => x.Id == id);      

            return p;
        }


        public void postPerson(Person person)
        {
            var db = new PersonDbContext();
            db.Add(person);
            db.SaveChanges();
        }

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

            u = db.User.FirstOrDefault(x => x.Email == user.Email && x.Password== user.Password);
            return u;
        }
       
    }
}
