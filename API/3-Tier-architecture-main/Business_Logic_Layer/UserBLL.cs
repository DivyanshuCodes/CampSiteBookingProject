using AutoMapper;
using System.Collections.Generic;
using WebApplication6.Repository.Entities;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
namespace Business_Logic_Layer
{
    public class UserBLL
    {
        private Data_Access_Layer.UserDAL _DAL;
        private Mapper _UserMapper;
        public UserBLL()
        {
            _DAL = new Data_Access_Layer.UserDAL();
            var _configCamp = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());

            _UserMapper = new Mapper(_configCamp);
        }
        public void addUser(UserModel userModel)
        {
            User UserEntity = _UserMapper.Map<UserModel, User>(userModel);
            _DAL.postUser(UserEntity);
        }

        public UserModel userLogin(User userModel)
        {
            User userEntity = _DAL.userLogin(userModel);

            UserModel userData = _UserMapper.Map<User, UserModel>(userEntity);

            return userData;
        }
    }
}
