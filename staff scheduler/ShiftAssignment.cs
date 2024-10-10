using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staff_scheduler
{
    public class ShiftAssignment
    {
        public int AssignmentId { get; set; }
        public Staff Staff { get; set; }
        public Shift Shift { get; set; }

        public Shift GetShiftDetails()
        {
            return Shift;
        }

        public Staff GetAssignedStaff()
        {
            return Staff;
        }
    }

}
