using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using DailyPlanner.DomainClasses.Interfaces;
using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.DomainClasses
{
    [DisplayColumn("Name")]
    public class ActivityType:IObjectWithState
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [NotMapped]
        public State DevSetState { get; set; }
    }
}