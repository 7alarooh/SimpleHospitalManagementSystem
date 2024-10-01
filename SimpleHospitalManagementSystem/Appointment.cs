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

        public DateTime AppointmentDate { get;private set; }
        public TimeSpan AppointmentTime { get; private set; }  // Start time of the appointment
        public bool IsBooked { get; set; }

        //Constructor to initialize the attributes
        public Appointment(Patient patient)
        {
            Patient = patient;
            IsBooked = false;  // Initially, the appointment is not booked
        }

        //this method to schedules an appointment between a patient and a doctor
        public void ScheduleAppointment(DateTime date) 
        {
            if (IsScheduled) { Console.WriteLine($"Appointment already scheduled for {Patient.Name} on {AppointmentDate}."); }
            else {
                AppointmentDate = date;
                IsScheduled=true;
            }
        }
        //this method to cancels the scheduled appointment
        public void CancelAppointment() 
        {
            if (!IsScheduled) { Console.WriteLine($"No appointment to cancel."); }
            else {
                Console.WriteLine($"Aappointment for {Patient.Name} with Dr.{Doctor.Name} on {AppointmentDate} has been canceled.");
                IsScheduled =false;                           
            }
        }

        //this method to displays appointment details.
        public void GetAppointmentDetails() 
        {
            if (!IsScheduled) { Console.WriteLine("No appointment to scheduled!"); }
            else {
                Console.WriteLine($"Appointment Detail:\t Patient ( {Patient.Name} ) \t Doctor: ( dr.{Doctor.Name} ) " +
                    $"Appointment Date: {AppointmentDate}\n ");
            }
        }

    }
}
