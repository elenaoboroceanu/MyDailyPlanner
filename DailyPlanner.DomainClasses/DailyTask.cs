using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

using DailyPlanner.DomainClasses.Interfaces;
using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.DomainClasses
{
    public class DailyTask:IObjectWithState
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
   
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [DisplayName("Duration in minutes")]
        [Required]
        [Remote("IsNumberEven", "DailyTask", ErrorMessage = "The number is odd.")]
        public int Duration { get; set; }


        [DisplayName("Start time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime StartTime { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public DailyTaskStatus DailyTaskStatus { get; set; }

        [NotMapped]
        public State DevSetState { get; set; }

     
 }
}