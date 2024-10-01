using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{// Enum for clinic specialization
    public enum Specialization
    {
        Cardiology,
        Neurology,
        Dermatology
    }
    public class Clinic
    {
        // Attributes
        public int ClinicID { get; private set; }  
        public string ClinicName { get; set; }  
        public Specialization Specialization { get; set; }  
        public List<Room> Rooms { get; private set; }  // List of rooms in the clinic
        public Dictionary<Doctor, List<Appointment>> AvailableAppointments { get; private set; }  // Doctor-appointment mapping

        // Constructor to initialize attributes
        public Clinic(int ClinicID, string ClinicName, Specialization Specialization)
        {
            this.ClinicID = ClinicID;
            this.ClinicName = ClinicName;
            this.Specialization = Specialization;
            Rooms = new List<Room>();
            // Initialize the AvailableAppointments dictionary
            AvailableAppointments = new Dictionary<Doctor, List<Appointment>>();
        }

    }
}
