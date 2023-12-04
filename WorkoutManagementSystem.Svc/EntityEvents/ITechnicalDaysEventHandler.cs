using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc.Infrastracture;

namespace WorkoutManagementSystem.Svc.EntityEvents
{
    public interface ITechnicalDaysEventHandler
    {
        bool NeedsCallToTechnicalDays(WorkoutManagementSystemContext context);
        string GetError(WorkoutManagementSystemContext context);
    }
}
