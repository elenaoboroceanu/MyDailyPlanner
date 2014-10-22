using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.Models
{
    [DisplayColumn("Name")]
    public class ActivityType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}