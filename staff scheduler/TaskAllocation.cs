using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staff_scheduler
{
    public class TaskAllocation
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public Staff AssignedStaff { get; set; }

        public void AssignTask(Staff staff)
        {
            AssignedStaff = staff;
        }

        public string GetTaskDetails()
        {
            return $"{TaskName} (ID: {TaskId})";
        }
    }

}
