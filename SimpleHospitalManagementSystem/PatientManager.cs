using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class PatientManager
    {
        // Dictionary to store patients with their IDs as the key
        private Dictionary<int, Patient> patients;

        // Constructor to initialize the dictionary
        public PatientManager()
        {
            patients = new Dictionary<int, Patient>();
        }

        // Method to add a patient
        public void AddPatient(Patient patient)
        {
            if (!patients.ContainsKey(patient.PatientID))
            {
                patients.Add(patient.PatientID, patient);
                Console.WriteLine($"Patient {patient.Name} added with ID {patient.PatientID}.");
            }
            else
            {
                Console.WriteLine($"Patient with ID {patient.PatientID} already exists.");
            }
        }

        // Method to get a patient by ID
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
    }

}
