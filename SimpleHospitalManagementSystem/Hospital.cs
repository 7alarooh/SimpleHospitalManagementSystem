using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleHospitalManagementSystem
{
    public class Hospital
    {
        //Attributes
        public List<Doctor> DoctorsList { get; set; }
        public List<Patient> PatientsList {  get; set; }
        public List<Room> RoomsList { get; set; }

        //Constructor initializes the lists
        public Hospital() 
        {
            DoctorsList = new List<Doctor>();
            PatientsList = new List<Patient>();
            RoomsList = new List<Room>();
        }

        //this method to add a new doctor
        public void AddDoctor(Doctor doctor) 
        {
            DoctorsList.Add(doctor);
            Console.WriteLine($"Doctor {doctor.Name} (ID: {doctor.DoctorID} has been added to the hospital.");
        }

        //this method to add a new patient
        public void AddPatient(Patient patient) 
        {
            PatientsList.Add(patient);
            Console.WriteLine($"Patient {patient.Name} (ID: {patient.PatientID} has been added to the hospital.");
        }

        //this method to  Assign a room to a patient
        public void AssignRoomToPatient(Patient patient, Room room) 
        {
            if (room.IsOccupied)
            {
                Console.WriteLine($"Room {room.RoomNumber} is already occupied!");
            }
            else 
            {
                patient.AssignRoom(room);
                room.OccupyRoom();
                Console.WriteLine($"Room {room.RoomNumber} has been assigned to Patient {patient.Name}. ");
            }
        }

        // this method to displays all patients assigned to a specific doctor
        public void GetDoctorPatients(Doctor doctor) 
        {
            if (DoctorsList.Count > 0)
            {
                Console.WriteLine($"Patients assigned to Dr.{doctor.Name} (ID: {doctor.DoctorID}:)");
                foreach (var doctorPatient in DoctorsList)
                {
                    Console.WriteLine($"{doctorPatient.Name} \t (Patient ID:{doctorPatient.DoctorID}) ");
                }
            }
            else { Console.WriteLine($"Dr.{doctor} has no patients assigned."); }
        }
    }
}
