using static SimpleHospitalManagementSystem.Person;
using static SimpleHospitalManagementSystem.Room;

namespace SimpleHospitalManagementSystem
{
    public class Program
    {
        private static Hospital hospital = new Hospital();

        public static void Main(string[] args)
        {// Create a hospital instance
            loginPage();
        }
        private static void loginPage() 
        {
            Login loginSystem = new Login();
            // Create a patient manager instance
            PatientManager patientManager = new PatientManager();
            // Register some users (Doctor and Patient) for testing
            patientManager.AddPatient(new InPatient(1, "John Doe", 30, Gender.Male, "password123", "Flu", new Doctor(101,"Dr. Smith",36,Gender.Male,Specializations.Cardiology,"123abcd"), DateTime.Now));
            patientManager.AddPatient(new OutPatient(2, "Jane Doe", 25, Gender.Female, "mypassword", "Skin Allergy", new Clinic(1, "Dermatology Clinic", Specialization.Dermatology)));


            while (true)
            {
                Console.Clear();  
                Console.WriteLine("==== Welcome to Hospital Management System ====");
                Console.WriteLine("Please log in:");

                // Prompt user for login details
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                // Attempt to log in
                var role = loginSystem.LoginUser(id,password);

                if (role != null)
                {
                    Console.WriteLine($"Login successful! Welcome, {role} with ID {id}.");

                    // Depending on role, show different menus
                    if (role == "Doctor")
                    {
                        DoctorMenu();
                    }
                    else if (role == "Patient")
                    {
                        // Get the patient using the hospital instance
                        Patient patient = hospital.GetPatientById(id);

                        if (patient != null)
                        {
                            PatientMenu(patient);
                        }
                        else
                        {
                            Console.WriteLine("Patient not found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID or Password. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        

        // Method to display Patient menu
        public static void PatientMenu(Patient patient)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Patient Menu ---");
                Console.WriteLine("1. Display Info");
                Console.WriteLine("2. Assign Room");
                Console.WriteLine("3. Discharge");
                Console.WriteLine("4. Schedule Appointment");
                Console.WriteLine("5. Cancel Appointment");
                Console.WriteLine("6. Display Appointment Details");
                Console.WriteLine("7. Display Room Info");
                Console.WriteLine("0. Exit");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        patient.DisplayInfo();
                        break;
                    case "2":
                        // Display available rooms for the patient to choose from
                        Console.WriteLine("\nAvailable Rooms:");
                        foreach (var room in availableRooms)
                        {
                            room.DisplayRoomInfo(); // Display room info to help patient choose
                        }
                        Console.Write("\nEnter room number to assign: ");
                        int roomNumber = int.Parse(Console.ReadLine());

                        // Find the room with the given room number
                        Room assignedRoom = availableRooms.Find(r => r.RoomNumber == roomNumber);
                        if (assignedRoom != null)
                        {
                            patient.AssignRoom(assignedRoom);
                        }
                        else
                        {
                            Console.WriteLine("Room not found. Please try again.");
                        }
                        break;
                    case "3":
                        patient.Discharge();
                        break;
                    case "4":
                        // Appointment Scheduling Logic
                        Console.Write("Enter appointment date (YYYY-MM-DD): ");
                        DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter appointment time (HH:MM): ");
                        TimeSpan appointmentTime = TimeSpan.Parse(Console.ReadLine());

                        // Schedule appointment logic here
                        patient.ScheduleAppointment(appointmentDate, appointmentTime);
                        Console.WriteLine($"Appointment scheduled on {appointmentDate.ToShortDateString()} at {appointmentTime}.");
                        break;
                    case "5":
                        // Cancel appointment logic here
                        patient.CancelAppointment();
                        Console.WriteLine("Appointment canceled.");
                        break;
                    case "6":
                        // Display appointment details
                        patient.DisplayAppointmentDetails();
                        break;
                    case "7":
                        // Display patient's current room info
                        if (patient.AssignedRoom != null)
                        {
                            patient.AssignedRoom.DisplayRoomInfo();
                        }
                        else
                        {
                            Console.WriteLine("No room assigned to the patient.");
                        }
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }



        // Method to display Doctor menu
        static void DoctorMenu()
        {
            Console.Clear();
            Console.WriteLine("==== Doctor Dashboard ====");
            Console.WriteLine("1. View patient list");
            Console.WriteLine("2. Add patient");
            Console.WriteLine("3. Remove patient");
            Console.WriteLine("4. Logout");
            // Implement doctor-specific functionalities here
            Console.ReadKey();
        }
    }
}
