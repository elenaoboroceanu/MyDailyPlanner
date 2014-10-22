using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.Models
{
    public class DailyTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }
   
        [DisplayName("Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Duration in minutes")]
        public int Duration { get; set; }


        [DisplayName("Start time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime StartTime { get; set; }

        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

 }
}