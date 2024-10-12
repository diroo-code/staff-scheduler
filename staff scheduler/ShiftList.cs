using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staff_scheduler
{
    public class ShiftList
    {
        public List<Shift> Shifts { get; private set; }

        public ShiftList()
        {
            Shifts = new List<Shift>();
        }

        public void AddShift(Shift shift)
        {
            Shifts.Add(shift);
        }
    }

}
