using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication6.Repository;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampController : ControllerBase
    {
        private Business_Logic_Layer.CampBLL _BLL;
        public CampController()
        {
            _BLL = new Business_Logic_Layer.CampBLL();
        }
        [HttpPost("postCamp")]
        public void postCamp([FromBody] CampModel campModel)
        {
            _BLL.addCamp(campModel);
        }
        [HttpGet("getCamp")]
        public List<CampModel> getCamp()
        {
            return _BLL.showAllCamp();
        }
        [HttpPost("deleteCamp")]
        public void deleteCamp([FromBody] CampModel campModel)
        {
            _BLL.deleteCamp(campModel);
        }
        [HttpGet("findCamp")]
        public CampModel findCamp([FromBody] CampModel campModel)
        {
            CampModel camp = _BLL.getCampById(campModel);
            if (camp == null)
            {
                return null;
            }
            return camp;
        }
        //[HttpGet("findCamp")]
        //public CampModel findCamp([FromBody]String CampId)
        //{
        //    CampModel camp = _BLL.getCampById(CampId);
        //    if (camp == null)
        //    {
        //        return null;
        //    }
        //    return camp;
        //}

        [HttpPost("editCamp")]
        public void editCamp([FromBody] CampModel campModel)
        {
            CampModel camp = campModel;
            this.deleteCamp(campModel);
            this.postCamp(camp);
        }
        [HttpGet("filterCamp")]
        public List<CampModel> filter([FromBody] CampModel campModel)
        {
            return _BLL.filterCamp(campModel);
        }
    }
}
