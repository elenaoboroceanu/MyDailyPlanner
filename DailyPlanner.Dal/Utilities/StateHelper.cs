using System.Data.Entity;

using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.Dal.Utilities
{
    public class StateHelper
    {
        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;                
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}
