﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staff_scheduler
{
    public class StaffList
    {
        public List<Staff> StaffMembers { get; private set; }

        public StaffList()
        {
            StaffMembers = new List<Staff>();
        }

        public void AddStaff(Staff staff)
        {
            StaffMembers.Add(staff);
        }

        public Staff GetStaff(int id)
        {
            return StaffMembers.FirstOrDefault(s => s.Id == id);
        }
    }

}
