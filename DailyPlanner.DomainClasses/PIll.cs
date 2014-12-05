using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.DomainClasses
{
    public class Pill
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public int Days { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}
