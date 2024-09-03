using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic_Layer.Models
{
    public class RatingModel
    {
        [Key]
        public int Id { get; set; }
        public string CampId { get; set; }
        public int TotalRating { get; set; }
        public int NumberRating { get; set; }
        public int AverageRating { get; set; }
    }
}
