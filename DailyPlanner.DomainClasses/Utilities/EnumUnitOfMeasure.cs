using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPlanner.DomainClasses.Utilities
{
    public enum UnitOfMeasure
    {
        [Display(Name = "Drops")]
        Drops = 0,
        [Display(Name = "Mililiters")]
        Mills = 1,
        [Display(Name = "Pill")]
        Pill = 2,
        [Display(Name = "Sachet")]
        Sachet = 3
    }
}
