using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer
{
    public class RatingBLL
    {
        private Data_Access_Layer.RatingDAL _DAL;
        private Mapper _RatingMapper;
        public RatingBLL()
        {
            _DAL = new Data_Access_Layer.RatingDAL();
            var _configRating = new MapperConfiguration(cfg => cfg.CreateMap<Rating, RatingModel>().ReverseMap());

            _RatingMapper = new Mapper(_configRating);
        }
        public void addRating(RatingModel ratingModel)
        {
            Rating entity = _RatingMapper.Map<RatingModel, Rating>(ratingModel);
            _DAL.addRating(entity);

        }
      
    }
}
