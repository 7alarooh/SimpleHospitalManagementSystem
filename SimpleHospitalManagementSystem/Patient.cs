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

        //Constructor to initialize the attributes and assign a doctor
        public Patient(int patientID, string name, int age, Gender gender,string Password, string ailment)
             : base(name, age, gender, Password)
        {
            this.PatientID = patientID;
            this.Ailment = ailment;

        }


        //Methods
       
        // Method to display patient-specific information
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Patient ID: {PatientID} \t Ailment: {Ailment}");
        }




    }
}
