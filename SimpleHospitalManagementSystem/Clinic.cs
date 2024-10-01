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

        // Method to add rooms to the clinic
        public void AddRoom(Room room)
        {
            if (room == null)
            {
                Console.WriteLine("Invalid room.");
                return;
            }

            Rooms.Add(room);
            Console.WriteLine($"Room {room.RoomNumber} added to the clinic.");
        }
        // Method to add available appointments for a doctor on a specific day and time period
        public void AddAvailableAppointment(Doctor doctor, DateTime appointmentDay, TimeSpan period)
        {
            if (!AvailableAppointments.ContainsKey(doctor))
            {
                AvailableAppointments[doctor] = new List<Appointment>();
            }

            // Generate appointments based on the specified period (e.g., 1-hour slots)
            for (int i = 0; i < period.TotalHours; i++)
            {
                DateTime appointmentTime = appointmentDay.AddHours(i);
                Appointment appointment = new Appointment(null);  // No patient assigned yet
                appointment.ScheduleAppointment(appointmentTime, new TimeSpan(1, 0, 0));  // 1-hour slot
                AvailableAppointments[doctor].Add(appointment);
            }

            Console.WriteLine($"Appointments for Dr. {doctor.Name} on {appointmentDay.ToShortDateString()} have been added.");
        }

    }
}
