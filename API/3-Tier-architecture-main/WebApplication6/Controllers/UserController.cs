using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private Business_Logic_Layer.UserBLL _BLL;
        public UserController()
        {
            _BLL = new Business_Logic_Layer.UserBLL();
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
