using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using DailyPlanner.DomainClasses.Interfaces;
using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.DomainClasses
{
    public class Toy:IObjectWithState
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
        public ToyType ToyType { get; set; }


        public ICollection<Activity> Activities { get; set; }

        [NotMapped]
        public State DevSetState { get; set; }

    }
}