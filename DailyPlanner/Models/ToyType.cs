using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.Models
{
    [DisplayColumn("Name")]
    public class ToyType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }
    }
}