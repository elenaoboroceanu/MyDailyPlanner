using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        public int ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }

        public virtual ICollection<Flashcard> Flashcards { get; set; } 
    }
}