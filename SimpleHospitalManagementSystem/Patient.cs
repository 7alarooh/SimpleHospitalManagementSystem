using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Patient:Person
    {
        //Attributes specific to patient
        public int PatientID { get; set; }
        public string Ailment { get; set; }
        public Doctor AssignedDoctor { get; set; }
        public Room room { get; set; }

        //Constructor to initialize the attributes and assign a doctor
        public Patient(string Name, int Age, Gender Gender, int PatientID, string Ailment, Doctor Dr, Room room)
            : base(Name, Age, Gender) 
        { 
            this.PatientID = PatientID;
            this.Ailment = Ailment;
            AssignedDoctor = Dr;
            room = null;
        }




    }
}
