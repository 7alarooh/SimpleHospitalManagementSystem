﻿using System;
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

        //Methods

        //this method to schedules an appointment 
        public void ScheduleAppointment(DateTime appointmentDate, TimeSpan appointmentTime)
        {
            if (IsBooked) {
                Console.WriteLine($"An appointment is already booked for {Patient.Name} on {AppointmentDate:yyyy-MM-dd} at {AppointmentTime}.");
            }
            else {
                AppointmentDate = appointmentDate;
                AppointmentTime = appointmentTime;
                IsBooked = true;
                Console.WriteLine($"Appointment scheduled for {Patient.Name} on {AppointmentDate:yyyy-MM-dd} at {AppointmentTime}.");

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
