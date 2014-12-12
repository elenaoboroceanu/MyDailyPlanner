using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.DomainClasses
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Recipe { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}
