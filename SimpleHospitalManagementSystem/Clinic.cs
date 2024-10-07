using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public int ClinicID { get;  set; }  
        public string ClinicName { get; set; }  
        public Specialization Specialization { get; set; }  
        public List<Room> Rooms { get;  set; }  // List of rooms in the clinic
        public Dictionary<Doctor, List<Appointment>> AvailableAppointments { get;  set; }  // Doctor-appointment mapping

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
                Appointment appointment = new Appointment(null) // No patient assigned yet
                {
                    AppointmentDate = appointmentTime.Date,
                    AppointmentTime = TimeSpan.FromHours(i + 9), // Appointment times starting from 9:00 AM
                    IsBooked = false
                };
               AvailableAppointments[doctor].Add(appointment);
            }

            Console.WriteLine($"Appointments for Dr. {doctor.Name} on {appointmentDay.ToShortDateString()} have been added.");
        }

        // Method to book an appointment for a patient with a specific doctor at the clinic
        public void BookAppointment(Patient patient, Doctor doctor, DateTime appointmentDay, TimeSpan appointmentTime)
        {
            if (!AvailableAppointments.ContainsKey(doctor))
            {
                Console.WriteLine($"No available appointments for Dr. {doctor.Name}.");
                return;
            }

            // Find an available appointment slot that matches the requested time
            Appointment availableAppointment = AvailableAppointments[doctor].Find(app =>
                app.AppointmentDate.Date == appointmentDay.Date &&
                app.AppointmentTime == appointmentTime &&
                !app.IsBooked);

            if (availableAppointment == null)
            {
                Console.WriteLine($"No available appointment slot for Dr. {doctor.Name} at {appointmentTime} on {appointmentDay.ToShortDateString()}.");
            }
            else
            {
                // Book the appointment for the patient
                availableAppointment.Patient = patient;
                availableAppointment.ScheduleAppointment(appointmentDay, appointmentTime);
                Console.WriteLine($"Appointment booked for {patient.Name} with Dr. {doctor.Name} on {appointmentDay.ToShortDateString()} at {appointmentTime}.");
            }
        }
        public void CancelAppointment(Patient patient, Doctor doctor, DateTime appointmentDay, TimeSpan appointmentTime)
        {
            if (!AvailableAppointments.ContainsKey(doctor))
            {
                Console.WriteLine($"No appointments found for Dr. {doctor.Name}.");
                return;
            }

            // Find the booked appointment
            Appointment bookedAppointment = AvailableAppointments[doctor].Find(app =>
                app.AppointmentDate.Date == appointmentDay.Date &&
                app.AppointmentTime == appointmentTime &&
                app.IsBooked &&
                app.Patient == patient);

            if (bookedAppointment == null)
            {
                Console.WriteLine($"No booked appointment found for {patient.Name} with Dr. {doctor.Name} at {appointmentTime} on {appointmentDay.ToShortDateString()}.");
            }
            else
            {
                // Cancel the appointment
                bookedAppointment.IsBooked = false;
                bookedAppointment.Patient = null;
                Console.WriteLine($"Appointment for {patient.Name} with Dr. {doctor.Name} at {appointmentTime} on {appointmentDay.ToShortDateString()} has been canceled.");
            }
        }
        // Method to display all available appointments for the clinic, organized by doctor and time slot
        public void DisplayAvailableAppointments()
        {
            foreach (var doctorAppointments in AvailableAppointments)
            {
                Doctor doctor = doctorAppointments.Key;
                List<Appointment> appointments = doctorAppointments.Value;

                Console.WriteLine($"Available appointments for Dr. {doctor.Name}:");

                foreach (var appointment in appointments)
                {
                    if (!appointment.IsBooked)
                    {
                        Console.WriteLine($"- Date: {appointment.AppointmentDate.ToShortDateString()} | Time: {appointment.AppointmentTime}");
                    }
                }
            }
        }
        // Example method to get a doctor for a given out-patient

        public Doctor GetFirstDoctor()
        {
            // Return the first doctor in the available appointments
            return AvailableAppointments.Keys.FirstOrDefault();
        }
        public Appointment GetAppointmentForPatient(Patient patient)
        {
            // Iterate through all doctors to find an appointment for the patient
            foreach (var doctor in AvailableAppointments.Keys) // Assuming you have a Doctors list or collection
            {
                if (AvailableAppointments.ContainsKey(doctor))
                {
                    var appointment = AvailableAppointments[doctor].FirstOrDefault(a => a.Patient == patient && a.IsBooked);
                    if (appointment != null)
                    {
                        return appointment; // Return the first found appointment for the patient
                    }
                }
            }
            return null; // No appointment found
        }



    }
}
