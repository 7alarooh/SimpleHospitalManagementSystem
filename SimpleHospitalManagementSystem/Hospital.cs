using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Hospital
    {
        //Attributes
        public List<Doctor> DoctorsList { get; set; }
        public List<Patient> PatientsList {  get; set; }
        public List<Room> RoomsList { get; set; }

        //Constructor initializes the lists
        public Hospital() 
        {
            DoctorsList = new List<Doctor>();
            PatientsList = new List<Patient>();
            RoomsList = new List<Room>();
        }

    }
}
