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
        public OutPatient(int patientID, string name, int age, Gender gender,string Password, string ailment, Clinic clinicAssigned)
            : base(patientID, name, age, gender,Password, ailment)
        {
            this.ClinicAssigned = clinicAssigned;
        }

        //methods 
        // Override the DisplayInfo() method to include clinic and upcoming appointments
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Assigned Clinic: {ClinicAssigned.ClinicName}");

            // Display upcoming appointments if available
            if (ClinicAssigned.AvailableAppointments.Count > 0)
            {
                Console.WriteLine("Upcoming Appointments:");
                foreach (var appointment in ClinicAssigned.AvailableAppointments)
                {
                    Console.WriteLine($"{appointment.Key}:");
                    foreach (var slot in appointment.Value)
                    {
                        Console.WriteLine($"\tTime Slot: {slot}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No upcoming appointments.");
            }
        }

        }
}
