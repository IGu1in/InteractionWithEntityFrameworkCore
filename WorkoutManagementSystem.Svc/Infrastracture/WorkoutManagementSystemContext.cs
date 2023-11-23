using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutManagementSystem.Svc.Infrastracture
{
    public class WorkoutManagementSystemContext : DbContext
    {
        public WorkoutManagementSystemContext(DbContextOptions<WorkoutManagementSystemContext> options) : base(options) 
        {
            
        }
    }
}
