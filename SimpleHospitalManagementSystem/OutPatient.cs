using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class OutPatient : Patient
    {
        // Attribute specific 
        public Clinic ClinicAssigned { get; private set; }

        // Constructor to initialize the out-patient attributes
        public OutPatient(int patientID, string name, int age, Gender gender, string ailment, Clinic clinicAssigned)
            : base(patientID, name, age, gender, ailment)
        {
            this.ClinicAssigned = clinicAssigned;
        }
    }
}
