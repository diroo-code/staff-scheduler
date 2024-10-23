using System;
using System.Collections.Generic;
using staffschedulerlibrary.Models;
using Google.Cloud.Firestore;

namespace staffschedulerlibrary.Models
{
    [FirestoreData]
    public class Shift
    {
        [FirestoreProperty]
        public int ShiftId { get; set; }

        [FirestoreProperty]
        public DateTime StartTime { get; set; }

        [FirestoreProperty]
        public DateTime EndTime { get; set; }

        [FirestoreProperty]
        public List<ShiftAssignment> ShiftAssignments { get; set; } // Changed from AssignedStaff

        public Shift()
        {
            ShiftAssignments = new List<ShiftAssignment>();
        }

        public void AddStaff(Staff staff)
        {
            var assignment = new ShiftAssignment(staff, this);
            ShiftAssignments.Add(assignment);
        }
    }
}
