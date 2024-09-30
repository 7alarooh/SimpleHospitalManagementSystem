using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Doctor:Person
    {
        //Attributes specific to doctor
        public int DoctorID { get; set; }   
        public string Specialization {  get; set; }
        public List<Patient> PatientsList { get; set; }

        //Constructor to initialize the attributes

        public Doctor(int DoctorID, string Name, int Age, Gender Gender,  string Specialization)
            : base(Name, Age, Gender)
        {
            this.DoctorID = DoctorID;
            this.Specialization = Specialization;
            this.PatientsList = new List<Patient>();
        }

        //method to add a patient to the doctor’s list
        public void AddPatient(Patient patient) 
        {
            PatientsList.Add(patient);
            Console.WriteLine($"Patient {patient.Name} added to Dr. {Name}'s list.");
        }
        public void RemovePatient(Patient patient)
        {
            if (PatientsList.Contains(patient))
            {
                PatientsList.Remove(patient);
                Console.WriteLine($"Patient {patient.Name} removed to Dr. {Name}'s list.");
            }
            else {
                Console.WriteLine($"Patient {patient.Name} is not assigned to Dr. {Name}.");
            }
        }
        //Override the DisplayInfo() method to include PatientID and Ailment
        public override void DisplayInfo() 
        {
            base.DisplayInfo();
            Console.WriteLine($"Doctor ID: {DoctorID} \t Specialization: {Specialization} \n ");
            //to display all Patients for doctor
            if (PatientsList.Count > 0)
            {
                Console.WriteLine("The Patients List:");
                foreach (Patient pat in PatientsList)
                {

                    Console.WriteLine($"Patient Name: {pat.Name} \t ID: {pat.PatientID} \n ");
                }
            }
            else
            { Console.WriteLine("No patients assigned!");}
        }

    }
}
