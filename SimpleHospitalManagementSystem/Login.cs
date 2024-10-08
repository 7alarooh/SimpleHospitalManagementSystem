using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Login
    {
        public Hospital hospital;
        public Login(Hospital hospital)
        {
            this.hospital = hospital; // Inject hospital instance to access its data
        }
       
        public string LoginUser(int id, string password)
        {
            // Check if the user is a doctor
            Doctor doctor = hospital.GetDoctorById(id);
            if (doctor != null && doctor.Password == password)
            {
                return "Doctor";
            }

            // Check if the user is a Records Clerk
            RecordsClerk RClerk = hospital.GetRecordsClerkById(id);
            if (RClerk != null && RClerk.Password == password)
            {
                return "RecordsClerk";
            }

            // Check if the user is a patient
            Patient patient = hospital.GetPatientById(id);
            if (patient != null && patient.Password == password)
            {
                return "Patient";
            }

            return null;  // Return null if login fails
        }

        
    }
    }

