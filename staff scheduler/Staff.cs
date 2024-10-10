using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staff_scheduler
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<TaskAllocation> TaskAllocations { get; set; }

        public Staff()
        {
            TaskAllocations = new List<TaskAllocation>();
        }

        public void AssignToShift(Shift shift)
        {
            shift.AddStaff(this);
        }

        public List<TaskAllocation> GetTaskAllocations()
        {
            return TaskAllocations;
        }
    }

}
