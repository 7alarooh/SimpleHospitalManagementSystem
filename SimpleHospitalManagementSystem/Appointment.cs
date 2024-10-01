using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Appointment
    {

        //attributes
        public Patient Patient { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; private set; }  // Start time of the appointment
        public bool IsBooked { get; set; }

        //Constructor to initialize the attributes
        public Appointment(Patient patient)
        {
            Patient = patient;
            IsBooked = false;  // Initially, the appointment is not booked
        }

        //Methods

        //this method to schedules an appointment 
        public void ScheduleAppointment(DateTime appointmentDate, TimeSpan appointmentTime)
        {
            if (IsBooked) {
                Console.WriteLine($"An appointment is already booked for {Patient.Name} on {AppointmentDate:yyyy-MM-dd} at {AppointmentTime}.");
            }
            else {
                //AppointmentDate = appointmentDate;
                //AppointmentTime = appointmentTime;
                AppointmentDate = appointmentDate.Date.Add(appointmentTime);
                IsBooked = true;
                Console.WriteLine($"Appointment scheduled for {Patient.Name} on {AppointmentDate:yyyy-MM-dd} at {AppointmentTime}.");

            }
        }
        //this method to cancels the scheduled appointment
        public void CancelAppointment() 
        {
            if (!IsBooked) { Console.WriteLine($"No appointment to cancel."); }
            else {
                Console.WriteLine($"Aappointment for {Patient.Name} on {AppointmentDate:yyyy-MM-dd} at {AppointmentTime} has been canceled !");
                IsBooked =false;                           
            }
        }

        //this method to displays appointment details.
        public void DisplayAppointmentDetails()
        {
            if (!IsBooked)
            {
                Console.WriteLine("No appointment is scheduled!");
            }
            else
            {
                Console.WriteLine($"Appointment Details:\nPatient: {Patient.Name}\nDate: {AppointmentDate:yyyy-MM-dd}\nTime: {AppointmentTime}");
            }
        }

    }
}
