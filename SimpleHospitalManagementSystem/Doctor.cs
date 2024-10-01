using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    // Enum for Doctor Specialization
    public enum Specializations
    {
        Cardiology,
        Neurology,
        Dermatology
    }
    public class Doctor:Person
    {
        
        //Attributes specific to doctor
        public int DoctorID { get; set; }   
        public Specializations Specialization {  get; set; }
        public List<Clinic> AssignedClinics { get; set; }
        public List<Patient> PatientsList { get; set; }

        //Constructor to initialize the attributes
        public Doctor(int DoctorID, string Name, int Age, Gender Gender, Specializations Specialization, string Password)
            : base(Name, Age, Gender, Password)
        {
            this.DoctorID = DoctorID;
            this.Specialization = Specialization;
            this.AssignedClinics = new List<Clinic>();
            this.PatientsList = new List<Patient>();
        }
        //method to add a patient to the doctor’s list
        public void AddPatient(Patient patient) 
        {
            if (!PatientsList.Contains(patient))
            {
                PatientsList.Add(patient);
                Console.WriteLine($"Patient {patient.Name} added to Dr. {Name}'s list.");
            }
            else
            {
                Console.WriteLine($"Patient {patient.Name} is already assigned to Dr. {Name}.");
            }
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
        // Assign doctor to a clinic with a specific day and period, generating 1-hour slots
        public void AssignToClinic(Clinic clinic, DateTime day, TimeSpan period)
        {
            // Validate period should not be less than 1 hour
            if (period < TimeSpan.FromHours(1))
            {
                Console.WriteLine("Period should be at least 1 hour.");
                return;
            }

            if (!AssignedClinics.Contains(clinic))
            {
                AssignedClinics.Add(clinic);
            }

            if (!clinic.Appointments.ContainsKey(day))
            {
                clinic.Appointments[day] = new List<TimeSpan>();
            }

            // Generate 1-hour slots for the specified period
            TimeSpan start = TimeSpan.Zero;
            while (start < period)
            {
                clinic.Appointments[day].Add(start);
                start += TimeSpan.FromHours(1);
            }

            Console.WriteLine($"Doctor {Name} assigned to {clinic.ClinicName} on {day.ToShortDateString()} for {period.TotalHours} hours.");
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
        // Display all clinics the doctor is assigned to
        public void DisplayAssignedClinics()
        {
            if (AssignedClinics.Count > 0)
            {
                Console.WriteLine($"Doctor {Name} is assigned to the following clinics:");
                foreach (var clinic in AssignedClinics)
                {
                    Console.WriteLine($"\tClinic: {clinic.ClinicName}");
                }
            }
            else
            {
                Console.WriteLine($"Doctor {Name} is not assigned to any clinics.");
            }
        }


    }
}
