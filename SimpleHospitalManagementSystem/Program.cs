using System.Numerics;
using System.Runtime.ConstrainedExecution;
using static SimpleHospitalManagementSystem.Person;
using static SimpleHospitalManagementSystem.Room;

namespace SimpleHospitalManagementSystem
{
    public class Program
    {            
        // Create a hospital instance
        static public Hospital hospital = new Hospital();
        static List<Room> availableRooms;
        static Clinic clinic;
        public static void Main(string[] args)
        {
            
            
            hospital.AddRecordsClerk(1001, "Alice Johnson", 28, Gender.Female, "123456");
            hospital.AddRecordsClerk(1002, "Omar Khalid", 28, Gender.Male, "123456");
            loginPage();
        }
        private static void loginPage()
        {
            Login loginSystem = new Login(hospital); // Pass hospital instance to the login system

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Welcome to Hospital Management System ====");
                Console.WriteLine("\nAre you [1] Patient (or) [2] Doctor (or) [3] Records Clerk: ");
                string select = Console.ReadLine();

                if (select == "1" || select == "2" || select=="3")
                {
                    Console.WriteLine("Please log in:");

                    // Prompt user for login details
                    Console.Write("Enter ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid ID format. Please enter a valid number.");
                        continue;
                    }

                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    // Attempt to log in and get the role
                    var role = loginSystem.LoginUser(id, password);

                    if (role != null)
                    {
                        Console.WriteLine($"Login successful! Welcome, {role} with ID {id}.");

                        // Depending on role, show different menus
                        if (role == "Doctor")
                        {
                            // Get the doctor object using the hospital instance
                            Doctor doctor = hospital.GetDoctorById(id);

                            if (doctor != null)
                            {
                                DoctorMenu(hospital, doctor); // Pass the doctor to the DoctorMenu
                            }
                            else
                            {
                                Console.WriteLine("Doctor not found.");
                            }
                        }
                        else if (role == "Patient")
                        {
                            // Get the patient using the hospital instance
                            Patient patient = hospital.GetPatientById(id);

                            if (patient != null)
                            {
                                PatientMenu(patient, availableRooms, clinic);
                            }
                            else
                            {
                                Console.WriteLine("Patient not found.");
                            }
                        }
                        else if (role == "RecordsClerk")
                        {
                            // Get the patient using the hospital instance
                            RecordsClerk RClerk = hospital.GetRecordsClerkById(id);

                            if (RClerk != null)
                            {
                                RecordsClerkMenu( hospital, RClerk);
                            }
                            else
                            {
                                Console.WriteLine("Records Clerk not found.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID or Password. Would you like to try again? [Y/N]");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            break;  // Exit the loop if the user chooses not to retry
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please choose either '1' for Patient or '2' for Doctor.");
                }
            }
        }

        // Method to display Patient menu
        public static void PatientMenu(Patient patient, List<Room> availableRooms, Clinic clinic)
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
                        patient.DisplayInfo();  // Display patient information
                        break;

                    case "2":
                        // Check if the patient is an in-patient for room assignment
                        if (patient is InPatient inPatient)
                        {
                            Console.WriteLine("\nAvailable Rooms:");
                            foreach (var room in availableRooms)
                            {
                                room.DisplayInfo(); // Display available rooms
                            }
                            Console.Write("\nEnter room number to assign: ");
                            if (int.TryParse(Console.ReadLine(), out int roomNumber))
                            {
                                Room assignedRoom = availableRooms.Find(r => r.RoomNumber == roomNumber);
                                if (assignedRoom != null)
                                {
                                    if (!assignedRoom.isOccupied)
                                    {
                                        inPatient.AssignRoom(assignedRoom);  // Assign room to in-patient
                                        Console.WriteLine($"Room {assignedRoom.RoomNumber} assigned to patient {patient.Name}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The selected room is already occupied.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Room not found. Please try again.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid room number. Please enter a valid number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Room assignment is only available for in-patients.");
                        }
                        break;

                    case "3":
                        // Check if the patient is an in-patient to discharge
                        if (patient is InPatient inpatientToDischarge)
                        {
                            inpatientToDischarge.Discharge();  // Discharge the in-patient
                        }
                        else
                        {
                            Console.WriteLine("Only in-patients can be discharged.");
                        }
                        break;

                    case "4":
                        // Schedule an appointment for out-patients
                        if (patient is OutPatient outPatient)
                        {
                            Console.Write("Enter appointment date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDate))
                            {
                                Console.Write("Enter appointment time (HH:MM): ");
                                if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan appointmentTime))
                                {
                                    // Get the first available doctor from the clinic assigned to the out-patient
                                    Doctor doctor = outPatient.ClinicAssigned.GetFirstDoctor();

                                    if (doctor != null)
                                    {
                                        // Now call the BookAppointment method with the patient, doctor, date, and time
                                        clinic.BookAppointment(outPatient, doctor, appointmentDate, appointmentTime);
                                        Console.WriteLine($"Appointment scheduled for {appointmentDate.ToShortDateString()} at {appointmentTime}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No doctor is available for this clinic.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid time format. Please try again.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Appointments can only be scheduled for out-patients.");
                        }

                        break;

                    case "5":
                        // Cancel an appointment for out-patients
                        if (patient is OutPatient cancelOutPatient)
                        {
                            Console.Write("Enter appointment date (YYYY-MM-DD) to cancel: ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime cancelDate))
                            {
                                Console.Write("Enter appointment time (HH:MM) to cancel: ");
                                if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan cancelTime))
                                {
                                    // Get the first available doctor from the clinic assigned to the out-patient
                                    Doctor doctor = cancelOutPatient.ClinicAssigned.GetFirstDoctor();

                                    if (doctor != null)
                                    {
                                        // Now call the CancelAppointment method with the patient, doctor, date, and time
                                        clinic.CancelAppointment(cancelOutPatient, doctor, cancelDate, cancelTime);  // Cancel appointment
                                        Console.WriteLine($"Appointment on {cancelDate.ToShortDateString()} at {cancelTime} canceled.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No doctor is available for this clinic.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid time format. Please try again.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Appointments can only be canceled for out-patients.");
                        }

                        break;

                    case "6":
                        // Assuming you have a way to access the appointments of the patient
                        var appointment = clinic.GetAppointmentForPatient(patient); // Replace this with actual logic to retrieve the appointment

                        if (appointment != null)
                        {
                            // Display appointment details for the appointment instance
                            appointment.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("No appointments found for the patient.");
                        }
                        break;

                    case "7":
                        // Display the patient's assigned room info (for in-patients only)
                        if (patient is InPatient inPatientRoomInfo && inPatientRoomInfo.AssignedRoom != null)
                        {
                            inPatientRoomInfo.AssignedRoom.DisplayInfo();  // Show room info
                        }
                        else
                        {
                            Console.WriteLine("No room assigned to the patient.");
                        }
                        break;

                    case "0":
                        // Exit the patient menu
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to display Doctor menu
        static void DoctorMenu(Hospital hospital, Doctor doctor)
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Doctor Menu ---");
                Console.WriteLine("1. View Assigned Patients");
                Console.WriteLine("2. View Available Rooms");
                Console.WriteLine("3. Assign Room to Patient");
                Console.WriteLine("4. Vacate Room for Patient");
                Console.WriteLine("5. Manage Appointments");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewAssignedPatients(hospital, doctor);
                        break;
                    case 2:
                        ViewAvailableRooms(hospital, doctor);
                        break;
                    case 3:
                        AssignRoomToPatient(hospital, doctor);
                        break;
                    case 4:
                        VacateRoomForPatient(hospital, doctor);
                        break;
                    case 5:
                        ManageAppointments(hospital, doctor);
                        break;
                    case 6:
                        Console.WriteLine("Exiting the Doctor Menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 6);
        }

        // Function to view assigned patients
        public static void ViewAssignedPatients(Hospital hospital, Doctor doctor)
        {
            hospital.GetDoctorPatients(doctor);
        }

        // Function to view available rooms in the hospital
        public static void ViewAvailableRooms(Hospital hospital, Doctor doctor)
        {
            Console.WriteLine("Available Rooms:");
            foreach (var room in hospital.RoomsList)
            {
                if (!room.isOccupied)
                {
                    room.DisplayInfo();
                }
            }
        }

        // Function to assign a room to a patient
        public static void AssignRoomToPatient(Hospital hospital, Doctor doctor)    
        {
            Console.Write("Enter the patient ID to assign a room: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Patient patient = hospital.GetPatientById(patientId);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }
            // Check if the patient is an in-patient before assigning a room
            if (patient is InPatient inPatient)
            {
                Console.WriteLine("Available Rooms:");
                foreach (var room in hospital.RoomsList)
                {
                    if (!room.isOccupied)
                    {
                        room.DisplayInfo();
                    }
                }

                // Display available rooms
                Console.WriteLine("Available Rooms:");
                foreach (var room in hospital.RoomsList)
                {
                    if (!room.isOccupied)
                    {
                        room.DisplayInfo();
                    }
                }

                Console.Write("Enter the room number to assign: ");
                int roomNumber = Convert.ToInt32(Console.ReadLine());
                Room roomToAssign = hospital.RoomsList.FirstOrDefault(r => r.RoomNumber == roomNumber && !r.isOccupied);

                if (roomToAssign != null)
                {
                    roomToAssign.OccupyRoom();
                    inPatient.AssignRoom(roomToAssign);
                    Console.WriteLine($"Room {roomNumber} assigned to Patient {patient.Name}.");
                }
                else
                {
                    Console.WriteLine("Room is not available or doesn't exist.");
                }
            }
            else { Console.WriteLine("Room assignment is only available for in-patients."); }
        }

            // Function to vacate a room for a patient
            public static void VacateRoomForPatient(Hospital hospital, Doctor doctor)
        {
            Console.Write("Enter the patient ID to vacate the room: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Patient patient = hospital.GetPatientById(patientId);
            if (patient is InPatient inPatient)
            {
                if (inPatient != null && inPatient.AssignedRoom != null)
                {
                    inPatient.AssignedRoom.VacateRoom();
                    inPatient.AssignRoom(null);
                    Console.WriteLine($"Room vacated for Patient {patient.Name}.");
                }
                else
                {
                    Console.WriteLine("Patient has no room assigned.");
                }
            }
        }

        // Function to manage appointments for the doctor
        public static void ManageAppointments(Hospital hospital, Doctor doctor)
        {
            Console.WriteLine("\n--- Manage Appointments ---");
            Console.WriteLine("1. View Available Appointments");
            Console.WriteLine("2. Schedule Appointment");
            Console.WriteLine("3. Cancel Appointment");
            Console.WriteLine("4. Back");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Assuming 'doctor' is an instance of the Doctor class
                    foreach (var clinic in doctor.AssignedClinics)
                    {
                        Console.WriteLine($"Available appointments at {clinic.ClinicName}:");
                        clinic.DisplayInfo(); // Call the method for each assigned clinic
                    }
                    break;
                case 2:
                    ScheduleAppointmentForPatient(hospital, doctor);
                    break;
                case 3:
                    CancelAppointmentForPatient(hospital, doctor);
                    break;
                case 4:
                    Console.WriteLine("Returning to the main menu.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        public static void ScheduleAppointmentForPatient(Hospital hospital, Doctor doctor)
        {
            Console.Write("Enter the patient ID to schedule an appointment: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Patient patient = hospital.GetPatientById(patientId);

            if (patient != null)
            {
                Console.Write("Enter appointment date (YYYY-MM-DD): ");
                DateTime appointmentDay = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter appointment time (HH:MM): ");
                TimeSpan appointmentTime = TimeSpan.Parse(Console.ReadLine());
                // Check if the doctor has assigned clinics
                if (doctor.AssignedClinics.Count > 0)
                {
                    // Display assigned clinics
                    Console.WriteLine("Assigned Clinics:");
                    for (int i = 0; i < doctor.AssignedClinics.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {doctor.AssignedClinics[i].ClinicName}");
                    }
                    Console.Write("Select a clinic by number: ");
                    int clinicChoice = Convert.ToInt32(Console.ReadLine());

                    // Validate the clinic choice
                    if (clinicChoice > 0 && clinicChoice <= doctor.AssignedClinics.Count)
                    {
                        Clinic selectedClinic = doctor.AssignedClinics[clinicChoice - 1]; // Get the selected clinic

                        // Schedule the appointment at the selected clinic
                        selectedClinic.BookAppointment(patient, doctor, appointmentDay, appointmentTime);
                    }
                    else
                    {
                        Console.WriteLine("Invalid clinic selection.");
                    }

                }
                else
                {
                    Console.WriteLine("Doctor has no assigned clinics.");
                }
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        public static void CancelAppointmentForPatient(Hospital hospital, Doctor doctor)
        {
            Console.Write("Enter the patient ID to cancel an appointment: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Patient patient = hospital.GetPatientById(patientId);

            if (patient != null)
            {
                Console.Write("Enter appointment date (YYYY-MM-DD): ");
                DateTime appointmentDay = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter appointment time (HH:MM): ");
                TimeSpan appointmentTime = TimeSpan.Parse(Console.ReadLine());

                // Check if the doctor has assigned clinics
                if (doctor.AssignedClinics.Count > 0)
                {
                    // Display assigned clinics
                    Console.WriteLine("Assigned Clinics:");
                    for (int i = 0; i < doctor.AssignedClinics.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {doctor.AssignedClinics[i].ClinicName}");
                    }
                    Console.Write("Select a clinic by number: ");
                    int clinicChoice = Convert.ToInt32(Console.ReadLine());

                    // Validate the clinic choice
                    if (clinicChoice > 0 && clinicChoice <= doctor.AssignedClinics.Count)
                    {
                        Clinic selectedClinic = doctor.AssignedClinics[clinicChoice - 1]; // Get the selected clinic

                        // Cancel the appointment at the selected clinic
                        selectedClinic.CancelAppointment(patient, doctor, appointmentDay, appointmentTime);
                    }
                    else
                    {
                        Console.WriteLine("Invalid clinic selection.");
                    }
                }
                else
                {
                    Console.WriteLine("Doctor has no assigned clinics.");
                }
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
        public static void RecordsClerkMenu(Hospital hospital, RecordsClerk clerk)
        {
            int choice;
            do
            {

                Console.WriteLine("\n--- Records Clerk Menu ---");
                Console.WriteLine("1. Create New Doctor");
                Console.WriteLine("2. Edit Doctor");
                Console.WriteLine("3. Remove Doctor");
                Console.WriteLine("4. Create New Patient");
                Console.WriteLine("5. Edit Patient");
                Console.WriteLine("6. Remove Patient");
                Console.WriteLine("7. Generate Patient Report");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateNewDoctor(hospital, clerk);
                        break;
                    case 2:
                        EditDoctor(hospital, clerk);
                        break;
                    case 3:
                        RemoveDoctor(hospital, clerk);
                        break;
                    case 4:
                        CreateNewPatient(hospital, clerk);
                        break;
                    case 5:
                        EditPatient(hospital, clerk);
                        break;
                    case 6:
                        RemovePatient(hospital, clerk);
                        break;
                    case 7:
                        GeneratePatientReport(hospital, clerk);
                        break;
                    case 0:
                        Console.WriteLine("Exiting Records Clerk Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

            while (choice != 0);
            }

        // Method to create a new doctor
        public static void CreateNewDoctor(Hospital hospital, RecordsClerk clerk)
        {
            Console.Write("Enter Doctor ID: ");
            int doctorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Doctor Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Doctor Gender (Male/Female): ");
            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
            Console.Write("Enter Doctor Specialization (Cardiology, Neurology, etc.): ");
            Specializations specialization = (Specializations)Enum.Parse(typeof(Specializations), Console.ReadLine());
            Console.Write("Enter Doctor Password: ");
            string password = Console.ReadLine();

            clerk.CreateDoctor(hospital, doctorId, name, age, gender, specialization, password);
        }

        // Method to edit an existing doctor
        public static void EditDoctor(Hospital hospital, RecordsClerk clerk)
        {
            Console.Write("Enter Doctor ID to edit: ");
            int doctorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Doctor Name (leave blank to skip): ");
            string newName = Console.ReadLine();
            Console.Write("Enter new Doctor Age (leave blank to skip): ");
            string ageInput = Console.ReadLine();
            int? newAge = string.IsNullOrEmpty(ageInput) ? (int?)null : Convert.ToInt32(ageInput);
            Console.Write("Enter new Doctor Specialization (leave blank to skip): ");
            string specializationInput = Console.ReadLine();
            Specializations? newSpecialization = string.IsNullOrEmpty(specializationInput) ? (Specializations?)null : (Specializations)Enum.Parse(typeof(Specializations), specializationInput);

            clerk.EditDoctor(hospital, doctorId, newName, newAge, newSpecialization);
        }

        // Method to remove a doctor
        public static void RemoveDoctor(Hospital hospital, RecordsClerk clerk)
        {
            Console.Write("Enter Doctor ID to remove: ");
            int doctorId = Convert.ToInt32(Console.ReadLine());
            clerk.RemoveDoctor(hospital, doctorId);
        }

        // Method to create a new patient
        public static void CreateNewPatient(Hospital hospital, RecordsClerk clerk)
        {
            Console.Write("Enter Patient ID: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Patient Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Patient Gender (Male/Female): ");
            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
            Console.Write("Enter Patient Ailment: ");
            string ailment = Console.ReadLine();
            Console.Write("Enter Patient Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Assigned Doctor ID: ");
            int doctorId = Convert.ToInt32(Console.ReadLine());
            Doctor assignedDoctor = hospital.GetDoctorById(doctorId);
            if (assignedDoctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }
            Console.Write("Enter Admission Date (YYYY-MM-DD): ");
            DateTime admissionDate = DateTime.Parse(Console.ReadLine());

            clerk.CreatePatient(hospital, patientId, name, age, gender, ailment, password, assignedDoctor, admissionDate);
        }

        // Method to edit an existing patient
        public static void EditPatient(Hospital hospital, RecordsClerk clerk)
        {
            Console.Write("Enter Patient ID to edit: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Patient Name (leave blank to skip): ");
            string newName = Console.ReadLine();
            Console.Write("Enter new Patient Age (leave blank to skip): ");
            string ageInput = Console.ReadLine();
            int? newAge = string.IsNullOrEmpty(ageInput) ? (int?)null : Convert.ToInt32(ageInput);
            Console.Write("Enter new Patient Ailment (leave blank to skip): ");
            string newAilment = Console.ReadLine();

            clerk.EditPatient(hospital, patientId, newName, newAge, newAilment);
        }

        // Method to remove a patient
        public static void RemovePatient(Hospital hospital, RecordsClerk clerk)
        {
            Console.Write("Enter Patient ID to remove: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            clerk.RemovePatient(hospital, patientId);
        }

        // Method to generate a patient report
        public static void GeneratePatientReport(Hospital hospital, RecordsClerk clerk)
        {
            Console.Write("Enter Patient ID to generate report for: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            clerk.GeneratePatientReport(hospital, patientId);
        }



    }

}
