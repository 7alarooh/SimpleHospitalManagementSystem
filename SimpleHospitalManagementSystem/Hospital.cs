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

        public List<Room> RoomsList { get; set; }

        //Constructor initializes the lists
        public Hospital() 
        {
            Doctors = new Dictionary<int, Doctor>();
            patients = new Dictionary<int, Patient>();
            RoomsList = new List<Room>();
        }

        //this method to add a new doctor
        //public void AddDoctor(Doctor doctor) 
        //{
        //    if (!Doctors.ContainsKey(doctor.DoctorID))
        //    {
        //        Doctors.Add(doctor.DoctorID, doctor);
        //        Console.WriteLine($"Doctor {doctor.Name} added with ID {doctor.DoctorID}.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Doctor with ID {doctor.DoctorID} already exists.");
        //    }
        //   }

        //this method to add a new patient
        //public void AddPatient(Patient patient) 
        //{
        //    if (!patients.ContainsKey(patient.PatientID))
        //    {
        //        patients.Add(patient.PatientID, patient);
        //        Console.WriteLine($"Patient {patient.Name} added with ID {patient.PatientID}.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Patient with ID {patient.PatientID} already exists.");
        //    }
        //}
        // Method to get a patient by their ID
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

        public Doctor GetDoctorById(int id) {
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


        //////////////////////////
    }
}
