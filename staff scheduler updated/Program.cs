using staffschedulerlibrary.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffScheduler
{
    class Program
    {
        static async Task Main(string[] args) // Changed to async to handle Firestore operations
        {
            // Initialize FirestoreManager with your Firebase project ID and the JSON credentials file path
            string projectId = "staffscheduler-369a1"; // Replace with Firebase project ID
            string credentialsFilePath = @"C:\Users\HP\Downloads\staffscheduler-369a1-firebase-adminsdk-zwe3k-d3e456ae2f.json";

            // Initialize FirestoreManager
            FirestoreManager firestoreManager = new FirestoreManager(projectId, credentialsFilePath);

            // Create StaffList and ShiftList
            StaffList staffList = new StaffList();
            ShiftList shiftList = new ShiftList();

            // Get user input to add staff
            AddStaff(staffList);

            // Save staff to Firestore
            foreach (var staff in staffList.StaffMembers)
            {
                await firestoreManager.SaveStaffAsync(staff); // Save staff to Firestore
            }

            // Get user input to add shifts
            AddShifts(shiftList);

            // Save shifts to Firestore
            foreach (var shift in shiftList.Shifts)
            {
                await firestoreManager.SaveShiftAsync(shift); // Save shift to Firestore
            }

            // Assign staff to shifts
            AssignStaffToShift(staffList, shiftList);

            // Allocate tasks to staff
            AllocateTasksToStaff(staffList);

            Console.WriteLine("\nAssignment and Task Allocation Complete.");
        }

        // Method to add staff via user input
        static void AddStaff(StaffList staffList)
        {
            Console.WriteLine("Enter the number of staff to add:");
            int staffCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < staffCount; i++)
            {
                Console.WriteLine($"Enter details for staff #{i + 1}");

                Console.Write("Staff ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Staff Name: ");
                string name = Console.ReadLine();

                Console.Write("Staff Position: ");
                string position = Console.ReadLine();

                // Add the staff member to the list
                Staff staff = new Staff { Id = id, Name = name, Position = position };
                staffList.AddStaff(staff);
            }
        }

        // Method to add shifts via user input
        static void AddShifts(ShiftList shiftList)
        {
            Console.WriteLine("Enter the number of shifts to add:");
            int shiftCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < shiftCount; i++)
            {
                Console.WriteLine($"Enter details for shift #{i + 1}");

                Console.Write("Shift ID: ");
                int shiftId = int.Parse(Console.ReadLine());

                Console.Write("Shift Start Time (e.g., yyyy-mm-dd hh:mm:ss): ");
                DateTime startTime = DateTime.Parse(Console.ReadLine()).ToUniversalTime();

                Console.Write("Shift End Time (e.g., yyyy-mm-dd hh:mm:ss): ");
                DateTime endTime = DateTime.Parse(Console.ReadLine()).ToUniversalTime();


                // Add the shift to the list
                Shift shift = new Shift { ShiftId = shiftId, StartTime = startTime, EndTime = endTime };
                shiftList.AddShift(shift);
            }
        }

        // Method to assign staff to shifts
        static void AssignStaffToShift(StaffList staffList, ShiftList shiftList)
        {
            Console.WriteLine("Assign staff to shifts.");

            foreach (var shift in shiftList.Shifts)
            {
                Console.WriteLine($"\nAssigning staff to Shift ID: {shift.ShiftId}");

                Console.WriteLine("Available Staff:");
                foreach (var staff in staffList.StaffMembers)
                {
                    Console.WriteLine($"{staff.Id}: {staff.Name} ({staff.Position})");
                }

                Console.WriteLine("Enter Staff IDs to assign to this shift (comma-separated):");
                string[] staffIds = Console.ReadLine().Split(',');

                foreach (var staffId in staffIds)
                {
                    var staff = staffList.GetStaff(int.Parse(staffId.Trim()));
                    if (staff != null)
                    {
                        // Create a new ShiftAssignment
                        var assignment = new ShiftAssignment(staff, shift);
                        shift.AddStaff(staff); // Add staff to shift
                        staff.ShiftAssignments.Add(assignment); // Add assignment to staff's list
                        Console.WriteLine($"{staff.Name} assigned to Shift {shift.ShiftId}");
                    }
                }
            }
        }

        // Method to allocate tasks to staff members
        static void AllocateTasksToStaff(StaffList staffList)
        {
            Console.WriteLine("\nTask Allocation:");

            foreach (var staff in staffList.StaffMembers)
            {
                Console.WriteLine($"\nAllocating tasks for {staff.Name}");

                Console.Write("Enter the number of tasks to allocate: ");
                int taskCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < taskCount; i++)
                {
                    Console.Write($"Enter Task Name for Task #{i + 1}: ");
                    string taskName = Console.ReadLine();

                    // Create and assign the task
                    TaskAllocation task = new TaskAllocation { TaskId = i + 1, TaskName = taskName };
                    task.AssignTask(staff);
                    staff.TaskAllocations.Add(task);

                    Console.WriteLine($"Task '{taskName}' assigned to {staff.Name}");
                }
            }
        }
    }
}
