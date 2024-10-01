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
        public InPatient(int patientID, string name, int age, Gender gender, string ailment, Doctor doctor, DateTime admissionDate)
            : base(patientID, name, age, gender, ailment)
        {
            this.AssignedDoctor = doctor;
            this.AdmissionDate = admissionDate;
            this.AssignedRoom = null; // Initially no room assigned
        }
    }
}
