using static SimpleHospitalManagementSystem.Person;
using static SimpleHospitalManagementSystem.Room;

namespace SimpleHospitalManagementSystem
{
    public class Program
    {
        private static Hospital hospital = new Hospital();
        static PatientManager patientManager = new PatientManager();

        public static void Main(string[] args)
        {
            // Create doctors
            Doctor doctor1 = new Doctor(3, "John Smith", 45, Gender.Male, Specializations.Cardiology,"123456");
            Doctor doctor4 = new Doctor(3, "Ali", 45, Gender.Male, Specializations.Cardiology, "123456");
            Doctor doctor2 = new Doctor(2, "Alice Brown", 38, Gender.Female, Specializations.Neurology,"123456");
            Doctor doctor3 = new Doctor(1, "Smith", 36, Gender.Male, Specializations.Dermatology, "123abcd");
            // Create clinics
            Clinic cardiologyClinic = new Clinic(2, "Cardiology Clinic", Specialization.Cardiology);
            Clinic neurologyClinic = new Clinic(3, "Neurology Clinic", Specialization.Neurology);
            Clinic dermatologyClinic = new Clinic(1, "Dermatology Clinic", Specialization.Dermatology);
           
            // Assign doctors to clinics and generate appointment slots (9 AM - 12 PM)
            doctor1.AssignToClinic(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(3)); // Expected: Appointments generated for 9 AM, 10 AM, 11 AM
            doctor2.AssignToClinic(neurologyClinic, new DateTime(2024, 10, 6), TimeSpan.FromHours(3));  // Expected: Appointments generated for 9 AM, 10 AM, 11 AM
            
            // Create rooms for clinics
            Room room1 = new Room(101, RoomType.IPR);  // Room for in-patients
            Room room2 = new Room(102, RoomType.OPR);  // Room for out-patients
            cardiologyClinic.AddRoom(room1); // Expected: Room 101 added to Cardiology Clinic
            neurologyClinic.AddRoom(room2);  // Expected: Room 102 added to Neurology Clinic

            // Create patients
            patientManager.AddPatient(new InPatient(1, "John Doe", 30, Gender.Male, "password123", "Cardiac Arrest", doctor1,  DateTime.Now));
            patientManager.AddPatient(new OutPatient(2, "Jane Doe", 25, Gender.Female, "mypassword", "Alice Brown", dermatologyClinic));
            Patient inpatient1 = patientManager.GetPatientById(1); // Get InPatient John Doe
            Patient outpatient1 = patientManager.GetPatientById(2); // Get OutPatient Jane Doe

            // Assign room to in-patient
            //inpatient1.AssignRoom(room1); // Expected: Room 101 becomes occupied
            if (inpatient1 is InPatient inPatientObj)
            {
                // Assign a room to the in-patient
                inPatientObj.AssignRoom(room1); // Expected: Room 101 becomes occupied
            }

            // Book an appointment for out-patient in Cardiology Clinic
            if (outpatient1 is OutPatient outPatientObj)
            {
                // Book an appointment for the out-patient in Cardiology Clinic
                outPatientObj.ClinicAssigned = cardiologyClinic; // Set the correct clinic
                cardiologyClinic.BookAppointment(outPatientObj, doctor1, new DateTime(2024, 10, 5), TimeSpan.FromHours(10)); // Expected: Appointment at 10 AM booked
                

            }
            
            cardiologyClinic.DisplayAvailableAppointments();

            // outpatient1.BookAppointment(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(10)); // Expected: Appointment at 10 AM booked
            // View doctor's assigned clinics
            doctor1.DisplayAssignedClinics(); // Expected: Cardiology Clinic is displayed
                                              // View available appointments in Cardiology Clinic
            cardiologyClinic.DisplayAvailableAppointments();
            // Expected: Show available slots for Dr. John Smith at 9 AM, 11 AM (10 AM is booked)
            // Discharge in-patient
            if (inpatient1 is InPatient inPatientOb)
            {
                inPatientOb.Discharge(); 
            }
            // inpatient1.Discharge(); // Expected: Room 101 becomes available, patient discharged
            // Book another appointment for the same out-patient in Cardiology Clinic
            if (outpatient1 is OutPatient outPatientObj1)
            {
                cardiologyClinic.BookAppointment(outPatientObj1, doctor1,new DateTime(2024, 10, 5), TimeSpan.FromHours(11)); // Expected: Appointment at 11 AM booked
                                                                                                                  // Try booking a time outside available slots
            }
            // outpatient1.BookAppointment(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(12));
            // Expected: No available appointments for this time
            // Cancel an appointment
            if (outpatient1 is OutPatient outPatientObj2)
            {
                cardiologyClinic.CancelAppointment(outPatientObj2, doctor1, new DateTime(2024, 10, 5), TimeSpan.FromHours(11));
            }
            // Expected: Appointment cancellation message for 10 AM
            // View available appointments after booking and cancellation
            cardiologyClinic.DisplayAvailableAppointments();
            // Expected: 10 AM slot available again, 9 AM and 11 AM booked


            // Create a hospital instance
            //loginPage();
        }
        //private static void loginPage() 
        //{
        //    Login loginSystem = new Login();
        //    // Create a patient manager instance
        //    PatientManager patientManager = new PatientManager();
        //    // Register some users (Doctor and Patient) for testing
        //    patientManager.AddPatient(new InPatient(1, "John Doe", 30, Gender.Male, "password123", "Flu", new Doctor(101,"Dr. Smith",36,Gender.Male,Specializations.Cardiology,"123abcd"), DateTime.Now));
        //    patientManager.AddPatient(new OutPatient(2, "Jane Doe", 25, Gender.Female, "mypassword", "Skin Allergy", new Clinic(1, "Dermatology Clinic", Specialization.Dermatology)));


        //    while (true)
        //    {
        //        Console.Clear();  
        //        Console.WriteLine("==== Welcome to Hospital Management System ====");
        //        Console.WriteLine("Please log in:");

        //        // Prompt user for login details
        //        Console.Write("Enter ID: ");
        //        int id = int.Parse(Console.ReadLine());

        //        Console.Write("Enter Password: ");
        //        string password = Console.ReadLine();

        //        // Attempt to log in
        //        var role = loginSystem.LoginUser(id,password);

        //        if (role != null)
        //        {
        //            Console.WriteLine($"Login successful! Welcome, {role} with ID {id}.");

        //            // Depending on role, show different menus
        //            if (role == "Doctor")
        //            {
        //                DoctorMenu();
        //            }
        //            else if (role == "Patient")
        //            {
        //                // Get the patient using the hospital instance
        //                Patient patient = hospital.GetPatientById(id);

        //                if (patient != null)
        //                {
        //                    PatientMenu(patient);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Patient not found.");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid ID or Password. Press any key to try again.");
        //            Console.ReadKey();
        //        }
        //    }
        //}



        //// Method to display Patient menu
        //public static void PatientMenu(Patient patient)
        //{
        //    bool exit = false;
        //    while (!exit)
        //    {
        //        Console.WriteLine("\n--- Patient Menu ---");
        //        Console.WriteLine("1. Display Info");
        //        Console.WriteLine("2. Assign Room");
        //        Console.WriteLine("3. Discharge");
        //        Console.WriteLine("4. Schedule Appointment");
        //        Console.WriteLine("5. Cancel Appointment");
        //        Console.WriteLine("6. Display Appointment Details");
        //        Console.WriteLine("7. Display Room Info");
        //        Console.WriteLine("0. Exit");

        //        Console.Write("\nSelect an option: ");
        //        string choice = Console.ReadLine();

        //        switch (choice)
        //        {
        //            case "1":
        //                patient.DisplayInfo();
        //                break;
        //            case "2":
        //                // Display available rooms for the patient to choose from
        //                Console.WriteLine("\nAvailable Rooms:");
        //                foreach (var room in availableRooms)
        //                {
        //                    room.DisplayRoomInfo(); // Display room info to help patient choose
        //                }
        //                Console.Write("\nEnter room number to assign: ");
        //                int roomNumber = int.Parse(Console.ReadLine());

        //                // Find the room with the given room number
        //                Room assignedRoom = availableRooms.Find(r => r.RoomNumber == roomNumber);
        //                if (assignedRoom != null)
        //                {
        //                    patient.AssignRoom(assignedRoom);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Room not found. Please try again.");
        //                }
        //                break;
        //            case "3":
        //                patient.Discharge();
        //                break;
        //            case "4":
        //                // Appointment Scheduling Logic
        //                Console.Write("Enter appointment date (YYYY-MM-DD): ");
        //                DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
        //                Console.Write("Enter appointment time (HH:MM): ");
        //                TimeSpan appointmentTime = TimeSpan.Parse(Console.ReadLine());

        //                // Schedule appointment logic here
        //                patient.ScheduleAppointment(appointmentDate, appointmentTime);
        //                Console.WriteLine($"Appointment scheduled on {appointmentDate.ToShortDateString()} at {appointmentTime}.");
        //                break;
        //            case "5":
        //                // Cancel appointment logic here
        //                patient.CancelAppointment();
        //                Console.WriteLine("Appointment canceled.");
        //                break;
        //            case "6":
        //                // Display appointment details
        //                patient.DisplayAppointmentDetails();
        //                break;
        //            case "7":
        //                // Display patient's current room info
        //                if (patient.AssignedRoom != null)
        //                {
        //                    patient.AssignedRoom.DisplayRoomInfo();
        //                }
        //                else
        //                {
        //                    Console.WriteLine("No room assigned to the patient.");
        //                }
        //                break;
        //            case "0":
        //                exit = true;
        //                break;
        //            default:
        //                Console.WriteLine("Invalid option. Please try again.");
        //                break;
        //        }
        //    }
        //}



        //// Method to display Doctor menu
        //static void DoctorMenu()
        //{
        //    Console.Clear();
        //    Console.WriteLine("==== Doctor Dashboard ====");
        //    Console.WriteLine("1. View patient list");
        //    Console.WriteLine("2. Add patient");
        //    Console.WriteLine("3. Remove patient");
        //    Console.WriteLine("4. Logout");
        //    // Implement doctor-specific functionalities here
        //    Console.ReadKey();
        //}
    }
}
