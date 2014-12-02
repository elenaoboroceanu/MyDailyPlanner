using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using DailyPlanner.DomainClasses.Interfaces;
using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.DomainClasses
{
    public class Activity:IObjectWithState
    {
        private ICollection<Toy> _toys;
        private ICollection<Flashcard> _flashcards;

        public Activity()
        {
            _toys = new List<Toy>();
            _flashcards = new List<Flashcard>();
        }


        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [StringLength(400)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int ActivityTypeId { get; set; }
        public  ActivityType ActivityType { get; set; } 

        public  ICollection<Toy> Toys
        {
            get { return _toys; }
            set { _toys = value; }
        }

        public  ICollection<Flashcard> Flashcards
        {
            get { return _flashcards; }
            set { _flashcards = value; }
        }
        [NotMapped]
        public State DevSetState { get; set; }
    }
}