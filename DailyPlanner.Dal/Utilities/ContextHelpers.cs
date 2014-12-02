using System.Data.Entity;

using DailyPlanner.DomainClasses.Interfaces;

namespace DailyPlanner.Dal.Utilities
{
    public static  class ContextHelpers
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                //Take the entity
                var stateInfo = entry.Entity;
                //Set state
                entry.State = StateHelper.ConvertState(stateInfo.DevSetState);
            }
        }
    }
}
