using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Patient:Person
    {
        //Attributes specific to patient
        public int PatientID { get; set; }
        public string Ailment { get; set; }
        public Doctor AssignedDoctor { get; set; }
        public Room AssignedRoom { get; set; }

        //Constructor to initialize the attributes and assign a doctor
        public Patient(string Name, int Age, Gender Gender, int PatientID, string Ailment, Doctor Dr, Room room)
            : base(Name, Age, Gender) 
        { 
            this.PatientID = PatientID;
            this.Ailment = Ailment;
            AssignedDoctor = Dr;
            AssignedRoom = null;
        }

        //Methods
        //Method to assign a room to the patient
        public void AssignRoom(Room room) 
        {
            AssignedRoom=room;
            Console.WriteLine($"Room {room.RoomNumber} assigned to patient {Name}.");
        }
        //Method to discharged the patient
        public void Discharge() 
        {
            AssignedRoom = null;
            Console.WriteLine($"Patient {Name} has been discharged.");
        }
        //Override the DisplayInfo() method to include PatientID and Ailment. 
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Patient ID: {PatientID} \t Ailment: {Ailment} \t Assigned Doctor: {AssignedDoctor.Name} ");
            if (AssignedRoom != null)
            {
                Console.WriteLine($"Assigned Room:{AssignedRoom.RoomNumber}");
            }
            else { Console.WriteLine("No Room Assigned"); }
        }




    }
}
