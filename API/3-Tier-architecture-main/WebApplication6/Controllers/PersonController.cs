using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Repository;
using WebApplication6.Repository.Entities;


namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class PersonController : ControllerBase
    {

        private Business_Logic_Layer.PersonBLL _BLL;
        public PersonController()
        {
            _BLL = new Business_Logic_Layer.PersonBLL();
        }

        [HttpGet]
        [Route("getPersons")]
        public List<PersonModel> GetAllPersons()
        {
            return _BLL.GetAllPersons();
        }

        [HttpGet]
        [Route("getPerson")]
        public ActionResult<PersonModel> GetPersonById(int id)
        {
            var person = _BLL.GetPersonById(id);

            if (person == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(person);
        }

        [HttpPost("postPerson")]
        public void postPerson([FromBody] PersonModel personModel)
        {
            _BLL.postPerson(personModel);
        }

        //(This is the bad practise!) = > this should instead also call the BLL 
        [Route("deletePerson")]
        [HttpDelete]
        public void deletePerson(int id)
        {
            var db = new PersonDbContext();
            Person p = new Person();
            p = db.Person.FirstOrDefault(x => x.Id == id);

            if (p == null)
                throw new Exception("Not found");

            db.Person.Remove(p);
            db.SaveChanges();
        }
        [HttpPost("postUser")]
        public void postUser([FromBody] UserModel userModel)
        {
            _BLL.addUser(userModel);
        }
       
        [HttpPost("getUser")]
        public ActionResult<UserModel> logUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var user = _BLL.userLogin(userObj);
            if (user == null)
                return NotFound(new { Message = "User Not Found!" });
            return Ok(
              new { Message = "Login Success!" }
              );
        }
    }
}
