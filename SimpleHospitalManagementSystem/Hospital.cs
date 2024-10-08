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
        // Dictionary to store doctors with their IDs as the key
        public Dictionary<int, Doctor> Doctors;
        // Dictionary to store patients with their IDs as the key
        public Dictionary<int, Patient> patients;
        //RecordsClerk
        public Dictionary<int, RecordsClerk> RecordsClerks;
        public List<Room> RoomsList { get; set; }

        //Constructor initializes the lists
        public Hospital()
        {
            Doctors = new Dictionary<int, Doctor>();
            patients = new Dictionary<int, Patient>();
            RoomsList = new List<Room>();
            RecordsClerks = new Dictionary<int, RecordsClerk>();
        }
        public RecordsClerk GetRecordsClerkById(int id)
        {
            if (RecordsClerks.ContainsKey(id))
            {
                return RecordsClerks[id];
            }
            else
            {
                Console.WriteLine($"No Records Clerk found with ID {id}.");
                return null;
            }
        }

        public Patient GetPatientById(int id)
        {
            if (patients.ContainsKey(id))
            {
                return patients[id];
            }
            else
            {
                Console.WriteLine($"No patient found with ID {id}.");
                return null;
            }
        }

        public Doctor GetDoctorById(int id)
        {
            if (Doctors.ContainsKey(id))
            {
                return Doctors[id];
            }
            else
            {
                Console.WriteLine($"No Doctor found with ID {id}.");
                return null;
            }
        }
        //this method to  Assign a room to a patient
        //public void AssignRoomToPatient(Patient patient, Room room) 
        //{
        //    if (room.IsOccupied)
        //    {
        //        Console.WriteLine($"Room {room.RoomNumber} is already occupied!");
        //    }
        //    else 
        //    {
        //        patient.AssignRoom(room);
        //        room.OccupyRoom();
        //        Console.WriteLine($"Room {room.RoomNumber} has been assigned to Patient {patient.Name}. ");
        //    }
        //}

        // this method to displays all patients assigned to a specific doctor
        public void GetDoctorPatients(Doctor doctor)
        {
            if (Doctors.Count > 0)
            {
                Console.WriteLine($"Patients assigned to Dr.{doctor.Name} (ID: {doctor.DoctorID}:)");
                foreach (var doctorPatient in Doctors)
                {
                    Console.WriteLine($"{doctorPatient.Value.Name} \t (Patient ID:{doctorPatient.Value.DoctorID}) ");
                }
            }
            else { Console.WriteLine($"Dr.{doctor} has no patients assigned."); }
        }
        public void AddRecordsClerk(int id, string name, int age, Gender gender, string password)
        {
            if (!RecordsClerks.ContainsKey(id))
            {
                RecordsClerk newClerk = new RecordsClerk(id, name, age, gender, password);
                RecordsClerks.Add(id, newClerk);
                Console.WriteLine($"Records Clerk {name} added successfully with ID {id}.");
            }
            else
            {
                Console.WriteLine($"A Records Clerk with ID {id} already exists.");
            }

            //////////////////////////
        }
    }
}
