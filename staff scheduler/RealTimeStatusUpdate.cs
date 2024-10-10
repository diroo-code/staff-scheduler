using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staff_scheduler
{
    public class RealTimeStatusUpdate
    {
        public Staff Staff { get; set; }
        public Shift Shift { get; set; }
        public string Status { get; set; }
        public DateTime UpdateTime { get; set; }

        public string GetStatus()
        {
            return $"{Staff.Name} is currently {Status} during shift {Shift.ShiftId} as of {UpdateTime}.";
        }

        public void SetStatus(string status)
        {
            Status = status;
            UpdateTime = DateTime.Now;
        }
    }

}
