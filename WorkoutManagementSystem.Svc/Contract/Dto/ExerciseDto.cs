using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    public class ExerciseDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
