using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer
{
    public class BookingBLL
    {
        private Data_Access_Layer.BookingDAL _DAL;
        private Mapper _BookingMapper;
        private Mapper _CampMapper;
        public BookingBLL()
        {
            _DAL = new Data_Access_Layer.BookingDAL();
            var _configBooking = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingModel>().ReverseMap());
            _BookingMapper = new Mapper(_configBooking);
            var _configCamp = new MapperConfiguration(cfg => cfg.CreateMap<Camp, CampModel>().ReverseMap());

            _CampMapper = new Mapper(_configCamp);
        }
        public void addBooking(BookingModel bookObj)
        {
            Booking bookEntity =_BookingMapper.Map<BookingModel, Booking>(bookObj);
            _DAL.addBooking(bookEntity);
        }
        public CampModel findBooking(string bookObj)
        {
           // Booking bookEntity = _BookingMapper.Map<BookingModel, Booking>(bookObj);
            Camp camp= _DAL.findBooking(bookObj);
            CampModel campModel = _CampMapper.Map<Camp, CampModel>(camp);
            return campModel;
        }
        public void deleteBooking(string referenceNo)
        {
            _DAL.deleteBooking(referenceNo);
        }
    }
}
