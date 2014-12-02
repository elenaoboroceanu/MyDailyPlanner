using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.DomainClasses.Interfaces
{
    public interface IObjectWithState
    {
        State DevSetState { get; set; }
    }
}
