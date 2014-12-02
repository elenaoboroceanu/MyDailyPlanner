using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.DomainClasses.Utilities
{
    public enum DailyTaskStatus
    {
        [Display(Name="To be done")]
        ToBeDone = 0,
        Doing = 1,
        Done = 2,
        [Display(Name="Not implemented")]
        NotImplemented=3
    }
}
