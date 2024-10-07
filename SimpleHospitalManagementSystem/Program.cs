using static SimpleHospitalManagementSystem.Person;
using static SimpleHospitalManagementSystem.Room;

namespace SimpleHospitalManagementSystem
{
    public class Program
    {            
        // Create a hospital instance
        static Hospital hospital = new Hospital();
        static List<Room> availableRooms;
        static Clinic clinic;
        public static void Main(string[] args)
        {
            //// Create doctors
            //Doctor doctor1 = new Doctor(3, "John Smith", 45, Gender.Male, Specializations.Cardiology,"123456");
            //Doctor doctor4 = new Doctor(3, "Ali", 45, Gender.Male, Specializations.Cardiology, "123456");
            //Doctor doctor2 = new Doctor(2, "Alice Brown", 38, Gender.Female, Specializations.Neurology,"123456");
            //Doctor doctor3 = new Doctor(1, "Smith", 36, Gender.Male, Specializations.Dermatology, "123abcd");
            //// Create clinics
            //Clinic cardiologyClinic = new Clinic(2, "Cardiology Clinic", Specialization.Cardiology);
            //Clinic neurologyClinic = new Clinic(3, "Neurology Clinic", Specialization.Neurology);
            //Clinic dermatologyClinic = new Clinic(1, "Dermatology Clinic", Specialization.Dermatology);

            //// Assign doctors to clinics and generate appointment slots (9 AM - 12 PM)
            //doctor1.AssignToClinic(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(3)); // Expected: Appointments generated for 9 AM, 10 AM, 11 AM
            //doctor2.AssignToClinic(neurologyClinic, new DateTime(2024, 10, 6), TimeSpan.FromHours(3));  // Expected: Appointments generated for 9 AM, 10 AM, 11 AM

            //// Create rooms for clinics
            //Room room1 = new Room(101, RoomType.IPR);  // Room for in-patients
            //Room room2 = new Room(102, RoomType.OPR);  // Room for out-patients
            //cardiologyClinic.AddRoom(room1); // Expected: Room 101 added to Cardiology Clinic
            //neurologyClinic.AddRoom(room2);  // Expected: Room 102 added to Neurology Clinic

            //// Create patients
            //hospital.AddPatient(new InPatient(1, "John Doe", 30, Gender.Male, "password123", "Cardiac Arrest", doctor1,  DateTime.Now));
            //hospital.AddPatient(new OutPatient(2, "Jane Doe", 25, Gender.Female, "mypassword", "Alice Brown", dermatologyClinic));
            //Patient inpatient1 = hospital.GetPatientById(1); // Get InPatient John Doe
            //Patient outpatient1 = hospital.GetPatientById(2); // Get OutPatient Jane Doe

            //// Assign room to in-patient
            ////inpatient1.AssignRoom(room1); // Expected: Room 101 becomes occupied
            //if (inpatient1 is InPatient inPatientObj)
            //{
            //    // Assign a room to the in-patient
            //    inPatientObj.AssignRoom(room1); // Expected: Room 101 becomes occupied
            //}

            //// Book an appointment for out-patient in Cardiology Clinic
            //if (outpatient1 is OutPatient outPatientObj)
            //{
            //    // Book an appointment for the out-patient in Cardiology Clinic
            //    outPatientObj.ClinicAssigned = cardiologyClinic; // Set the correct clinic
            //    cardiologyClinic.BookAppointment(outPatientObj, doctor1, new DateTime(2024, 10, 5), TimeSpan.FromHours(10)); // Expected: Appointment at 10 AM booked


            //}

            //cardiologyClinic.DisplayAvailableAppointments();

            //// outpatient1.BookAppointment(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(10)); // Expected: Appointment at 10 AM booked
            //// View doctor's assigned clinics
            //doctor1.DisplayAssignedClinics(); // Expected: Cardiology Clinic is displayed
            //                                  // View available appointments in Cardiology Clinic
            //cardiologyClinic.DisplayAvailableAppointments();
            //// Expected: Show available slots for Dr. John Smith at 9 AM, 11 AM (10 AM is booked)
            //// Discharge in-patient
            //if (inpatient1 is InPatient inPatientOb)
            //{
            //    inPatientOb.Discharge(); 
            //}
            //// inpatient1.Discharge(); // Expected: Room 101 becomes available, patient discharged
            //// Book another appointment for the same out-patient in Cardiology Clinic
            //if (outpatient1 is OutPatient outPatientObj1)
            //{
            //    cardiologyClinic.BookAppointment(outPatientObj1, doctor1,new DateTime(2024, 10, 5), TimeSpan.FromHours(11)); // Expected: Appointment at 11 AM booked
            //                                                                                                      // Try booking a time outside available slots
            //}
            //// outpatient1.BookAppointment(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(12));
            //// Expected: No available appointments for this time
            //// Cancel an appointment
            //if (outpatient1 is OutPatient outPatientObj2)
            //{
            //    cardiologyClinic.CancelAppointment(outPatientObj2, doctor1, new DateTime(2024, 10, 5), TimeSpan.FromHours(11));
            //}
            //// Expected: Appointment cancellation message for 10 AM
            //// View available appointments after booking and cancellation
            //cardiologyClinic.DisplayAvailableAppointments();
            //// Expected: 10 AM slot available again, 9 AM and 11 AM booked

          
            // Register some users (Doctor and Patient) for testing
            hospital.AddPatient(new InPatient(1, "John Doe", 30, Gender.Male, "password123", "Flu", new Doctor(101, "Dr. Smith", 36, Gender.Male, Specializations.Cardiology, "123abcd"), DateTime.Now));
            hospital.AddPatient(new OutPatient(2, "Jane Doe", 25, Gender.Female, "mypassword", "Skin Allergy", new Clinic(1, "Dermatology Clinic", Specialization.Dermatology)));
            Doctor doctor1 = new Doctor(3, "John Smith", 45, Gender.Male, Specializations.Cardiology, "123456");
            Doctor doctor4 = new Doctor(4, "Ali", 45, Gender.Male, Specializations.Cardiology, "123456");
            Doctor doctor2 = new Doctor(2, "Alice Brown", 38, Gender.Female, Specializations.Neurology, "123456");
            Doctor doctor3 = new Doctor(1, "Smith", 36, Gender.Male, Specializations.Dermatology, "123abcd");
            loginPage();
        }
        private static void loginPage()
        {
            Login loginSystem = new Login(hospital); // Pass hospital instance to the login system

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Welcome to Hospital Management System ====");
                Console.WriteLine("\nAre you [1] Patient (or) [2] Doctor: ");
                string select = Console.ReadLine();

                if (select == "1" || select == "2")
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
                            DoctorMenu();
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
                                room.DisplayRoomInfo(); // Display available rooms
                            }
                            Console.Write("\nEnter room number to assign: ");
                            if (int.TryParse(Console.ReadLine(), out int roomNumber))
                            {
                                Room assignedRoom = availableRooms.Find(r => r.RoomNumber == roomNumber);
                                if (assignedRoom != null)
                                {
                                    if (!assignedRoom.IsOccupied)
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
                            appointment.DisplayAppointmentDetails();
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
                            inPatientRoomInfo.AssignedRoom.DisplayRoomInfo();  // Show room info
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
