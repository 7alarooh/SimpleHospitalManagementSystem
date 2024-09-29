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
        public Doctor(string Name, int Age, Gender Gender, int DoctorID, string Specialization)
            : base(Name, Age, Gender)
        {
            this.DoctorID = DoctorID;
            this.Specialization = Specialization;
            this.PatientsList = new List<Patient>();
        }
    }
}
