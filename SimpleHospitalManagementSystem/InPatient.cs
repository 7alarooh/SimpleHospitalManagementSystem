using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class InPatient:Patient
    {
        // Additional attributes specific to in-patient
        public Room AssignedRoom { get; private set; }
        public Doctor AssignedDoctor { get; private set; }
        public DateTime AdmissionDate { get; private set; }
        // Constructor to initialize the in-patient attributes
        public InPatient(int patientID, string name, int age, Gender gender, string Password, string ailment, Doctor doctor, DateTime admissionDate)
            : base(patientID, name, age, gender,Password, ailment)
        {
            this.AssignedDoctor = doctor;
            this.AdmissionDate = admissionDate;
            this.AssignedRoom = null; // Initially no room assigned
        }

        // Methods 
        // Method to assign a room to the in-patient
        public void AssignRoom(Room room)
        {
            AssignedRoom = room;
            Console.WriteLine($"Room {room.RoomNumber} assigned to patient {Name}.");
        }
        // Method to discharge the patient and free the room
        public void Discharge()
        {
            AssignedRoom = null;
            Console.WriteLine($"Patient {Name} has been discharged and the room is now free.");
        }
        // Override the DisplayInfo() method to include room and assigned doctor
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Assigned Doctor: {AssignedDoctor.Name} \t Admission Date: {AdmissionDate.ToShortDateString()}");

            if (AssignedRoom != null)
            {
                Console.WriteLine($"Assigned Room: {AssignedRoom.RoomNumber}");
            }
            else
            {
                Console.WriteLine("No Room Assigned");
            }
        }
        }
}
