using System;
using System.Collections.Generic;
using WebApplication6.Repository.Entities;
using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;

namespace Business_Logic_Layer
{
    public class PersonBLL
    {

        private Data_Access_Layer.PersonDAL _DAL;
        private Mapper _Mapper;
        private Mapper _UserMapper;
        private Mapper _CampMapper;
        public PersonBLL()
        {
            _DAL = new Data_Access_Layer.PersonDAL();
            var _configPerson = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonModel>().ReverseMap());
            var _configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());
            var _configCamp = new MapperConfiguration(cfg => cfg.CreateMap<Camp, CampModel>().ReverseMap());

            _Mapper = new Mapper(_configPerson);
            _UserMapper = new Mapper(_configUser);
            _CampMapper = new Mapper(_configCamp);
        }

        public List<PersonModel> GetAllPersons()
        {
           List<Person> personsFromDB = _DAL.GetAllPersons();
           List<PersonModel> personsModel = _Mapper.Map<List<Person>, List<PersonModel>>(personsFromDB);

            return personsModel;
        }

        public PersonModel GetPersonById(int id)
        {
           var personEntity = _DAL.GetPersonById(id);

            PersonModel personModel = _Mapper.Map<Person, PersonModel>(personEntity);

            return personModel;
        }
        
        public void postPerson(PersonModel personModel)
        {
            Person personEntity = _Mapper.Map<PersonModel, Person>(personModel);
            _DAL.postPerson(personEntity);
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
