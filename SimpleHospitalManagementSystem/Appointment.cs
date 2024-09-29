using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Appointment
    {

        //attributes
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get;private set; }
        public bool IsScheduled { get; set; }

        //Constructor to initialize the attributes
        public Appointment(Patient patient, Doctor Doctor) 
        {
            Patient = patient;
            this.Doctor = Doctor;
            IsScheduled = false;
        }    

    }
}
