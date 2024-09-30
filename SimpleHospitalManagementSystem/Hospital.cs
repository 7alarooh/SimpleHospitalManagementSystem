using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"Patient {patient.Name} (ID: {patient.PatientID} has been added to the hospital."
        }

        //this method to  Assign a room to a patient

        // this method to displays all patients assigned to a specific doctor


    }
}
