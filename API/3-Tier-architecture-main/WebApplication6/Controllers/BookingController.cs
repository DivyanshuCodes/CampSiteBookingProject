using Business_Logic_Layer.Models;
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

    public class BookingController : ControllerBase
    {
        private Business_Logic_Layer.BookingBLL _BLL;
        public BookingController()
        {
            _BLL = new Business_Logic_Layer.BookingBLL();
        }
        [HttpPost("addBooking")]
        public void addBooking([FromBody] BookingModel bookObj)
        {
            _BLL.addBooking(bookObj);
        }
        [HttpGet("findBooking/{bookObj}")]
        public CampModel findBooking(string bookObj)
        {
            CampModel campModel=_BLL.findBooking(bookObj);
            return campModel;
        }
        [HttpDelete("cancelBooking/{referenceNo}")]
        public void deleteBooking(string referenceNo)
        {
            _BLL.deleteBooking(referenceNo);
        }
    }
}
