using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class RecordsClerk : Person
    {
        public int ClerkID { get; set; }

        public RecordsClerk(int clerkID, string name, int age, Gender gender, string password)
            : base(name, age, gender, password)
        {
            this.ClerkID = clerkID;
        }
        // Method to create a new patient
        public void CreatePatient(Hospital hospital, int patientId, string name, int age, Gender gender, string ailment, string password, Doctor assignedDoctor, DateTime admissionDate)
        {
            if (!hospital.patients.ContainsKey(patientId))
            {
                InPatient newPatient = new InPatient(patientId, name, age, gender, password, ailment, assignedDoctor, admissionDate);
                hospital.patients.Add(patientId, newPatient);
                Console.WriteLine($"Patient {name} created and added to the hospital.");
            }
            else
            {
                Console.WriteLine("A patient with this ID already exists.");
            }
        }

        // Method to create a new doctor
        public void CreateDoctor(Hospital hospital, int doctorId, string name, int age, Gender gender, Specializations specialization, string password)
        {
            if (!hospital.Doctors.ContainsKey(doctorId))
            {
                Doctor newDoctor = new Doctor(doctorId, name, age, gender, specialization, password);
                hospital.Doctors.Add(doctorId, newDoctor);
                Console.WriteLine($"Doctor {name} created and added to the hospital.");
            }
            else
            {
                Console.WriteLine("A doctor with this ID already exists.");
            }
        }

        // Method to edit a patient's details
        public void EditPatient(Hospital hospital, int patientId, string newName = null, int? newAge = null, string newAilment = null)
        {
            if (hospital.patients.ContainsKey(patientId))
            {
                Patient patient = hospital.patients[patientId];
                if (newName != null) patient.Name = newName;
                if (newAge != null) patient.Age = (int)newAge;
                if (newAilment != null) patient.Ailment = newAilment;
                Console.WriteLine($"Patient {patientId} has been updated.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        // Method to remove a patient
        public void RemovePatient(Hospital hospital, int patientId)
        {
            if (hospital.patients.ContainsKey(patientId))
            {
                hospital.patients.Remove(patientId);
                Console.WriteLine($"Patient {patientId} has been removed from the hospital.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        // Method to edit a doctor's details
        public void EditDoctor(Hospital hospital, int doctorId, string newName = null, int? newAge = null, Specializations? newSpecialization = null)
        {
            if (hospital.Doctors.ContainsKey(doctorId))
            {
                Doctor doctor = hospital.Doctors[doctorId];
                if (newName != null) doctor.Name = newName;
                if (newAge != null) doctor.Age = (int)newAge;
                if (newSpecialization != null) doctor.Specialization = (Specializations)newSpecialization;
                Console.WriteLine($"Doctor {doctorId} has been updated.");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        // Method to remove a doctor
        public void RemoveDoctor(Hospital hospital, int doctorId)
        {
            if (hospital.Doctors.ContainsKey(doctorId))
            {
                hospital.Doctors.Remove(doctorId);
                Console.WriteLine($"Doctor {doctorId} has been removed from the hospital.");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        // Method to generate a report for any patient
        public void GeneratePatientReport(Hospital hospital, int patientId)
        {
            if (hospital.patients.ContainsKey(patientId))
            {
                Patient patient = hospital.patients[patientId];
                Console.WriteLine($"Patient Report for {patient.Name}:");
                Console.WriteLine($"ID: {patient.PatientID}");
                Console.WriteLine($"Age: {patient.Age}");
                Console.WriteLine($"Ailment: {patient.Ailment}");
                if (patient is InPatient inPatient)
                { Console.WriteLine($"Assigned Doctor: {inPatient.AssignedDoctor.Name}"); }
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
        public virtual void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Records Clerk ID: {ClerkID} ");
        }

    }
}
