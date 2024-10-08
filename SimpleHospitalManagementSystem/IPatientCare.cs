using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    // IPatientCare interface
    public interface IPatientCare
    {
        void ProvideCare(Patient patient); // Method to provide care to patients
    }
    /// IInPatientCare interface
    public interface IInPatientCare : IPatientCare
    {
        void AssignRoom(InPatient patient, Room room);   // Method to assign a room to an in-patient
        void DischargePatient(InPatient patient);         // Method to discharge an in-patient
    }
    /// IOutPatientCare interface
    public interface IOutPatientCare : IPatientCare
    {
        void ScheduleFollowUp(OutPatient patient);        // Method to schedule a follow-up appointment
    }


    
   

}
