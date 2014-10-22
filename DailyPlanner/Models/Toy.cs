using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DailyPlanner.Models
{
    public class Toy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        [StringLength(10)]
        public string Code { get; set; }

        
        [StringLength(400)]
        public string Description { get; set; }


       
        public int ToyTypeId { get; set; }
        public virtual ToyType ToyType { get; set; }


        public virtual ICollection<Activity> Activities { get; set; }
    }
}