using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staff_scheduler
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Staff> AssignedStaff { get; set; }
        public List<ShiftAssignment> ShiftAssignments { get; set; }

        public Shift()
        {
            AssignedStaff = new List<Staff>();
            ShiftAssignments = new List<ShiftAssignment>();
        }

        public void AddStaff(Staff staff)
        {
            AssignedStaff.Add(staff);
        }

        public List<ShiftAssignment> GetShiftAssignments()
        {
            return ShiftAssignments;
        }
    }

}
