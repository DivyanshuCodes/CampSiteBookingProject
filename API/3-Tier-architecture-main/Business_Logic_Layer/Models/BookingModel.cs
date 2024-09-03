using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic_Layer.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }
        public string BillingAddress { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string CellPhone { get; set; }
        public string ReferenceNo { get; set; }
        public string CampId { get; set; }
        public int TotalStay { get; set; }
        public int TotalAmount { get; set; }
    }
}
