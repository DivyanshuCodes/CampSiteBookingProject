using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access_Layer.Repository.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public string CampId { get; set; }
        public int TotalRating { get; set; }
        public int NumberRating { get; set; }
        public int AverageRating { get; set; }
    }
}
