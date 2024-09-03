using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic_Layer.Models
{
    public class CampModel
    {
        [Key]
        public int Id { get; set; }
        public string CampId { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public string Capacity { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
    }
}
