using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.Models
{
    public class Flashcard
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int FlashcardTypeId { get; set; }
        public virtual FlashcardType Type { get; set; }


        public virtual ICollection<Activity> Activities { get; set; }


    }
}