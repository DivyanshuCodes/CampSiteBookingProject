using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
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
    public class RatingController : ControllerBase
    {
        private Business_Logic_Layer.RatingBLL _BLL;
        public RatingController()
        {
            _BLL = new Business_Logic_Layer.RatingBLL();
        }
        [HttpPost("postRating")]
        public void addRating([FromBody] RatingModel rateModel)
        {
            _BLL.addRating(rateModel);
        }
        //[HttpPost("getRating/{referenceNo}")]
        //public int getRating(string campId)
        //{
        //    //return _BLL.getRating(campId);
        //}
    }
}
