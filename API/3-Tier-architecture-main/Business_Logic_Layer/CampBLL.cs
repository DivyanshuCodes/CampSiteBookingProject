using System;
using System.Collections.Generic;
using WebApplication6.Repository.Entities;
using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
namespace Business_Logic_Layer
{
   
    public class CampBLL
    {
        private Data_Access_Layer.CampDAL _DAL;
        private Mapper _CampMapper;
        public CampBLL()
        {
            _DAL = new Data_Access_Layer.CampDAL();
            var _configCamp = new MapperConfiguration(cfg => cfg.CreateMap<Camp, CampModel>().ReverseMap());

            _CampMapper = new Mapper(_configCamp);
        }
        public void addCamp(CampModel campModel)
        {
            Camp campEntity = _CampMapper.Map<CampModel, Camp>(campModel);
            _DAL.postCamp(campEntity);
        }
        public List<CampModel> showAllCamp()
        {
            List<Camp> campsFromDB = _DAL.getCamp();
            List<CampModel> campModel = _CampMapper.Map<List<Camp>, List<CampModel>>(campsFromDB);

            return campModel;
        }
        public void deleteCamp(CampModel campModel)
        {
            Camp campEntity = _CampMapper.Map<CampModel, Camp>(campModel);
            _DAL.deleteCamp(campEntity);
        }
        public CampModel getCampById(CampModel campModel)
        {
            Camp campEntity = _CampMapper.Map<CampModel, Camp>(campModel);
            Camp campObj = _DAL.GetCampById(campEntity);

            CampModel campObjt = _CampMapper.Map<Camp, CampModel>(campObj);

            return campObjt;
        }
        //public CampModel getCampById(String CampId)
        //{

        //    Camp campObj = _DAL.GetCampById(CampId);

        //    CampModel campObjt = _CampMapper.Map<Camp, CampModel>(campObj);

        //    return campObjt;
        //}
        public List<CampModel> filterCamp(CampModel campModel)
        {

            Camp campEntity = _CampMapper.Map<CampModel, Camp>(campModel);
            List<Camp> sortData = _DAL.filterCamp(campEntity);
            List<CampModel> finalData = _CampMapper.Map<List<Camp>, List<CampModel>>(sortData);
            return finalData;
        }
    }
}
