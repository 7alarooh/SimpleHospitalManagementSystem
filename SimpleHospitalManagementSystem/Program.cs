using static SimpleHospitalManagementSystem.Person;
using static SimpleHospitalManagementSystem.Room;

namespace SimpleHospitalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            loginPage();
        }
        static void loginPage() 
        {
            Login loginSystem = new Login();

            // Register some users (Doctor and Patient) for testing
            loginSystem.RegisterUser(101, "password123", "Doctor");
            loginSystem.RegisterUser(201, "mypassword", "Patient");

            while (true)
            {
                Console.Clear();  // Clear the console to make it feel like a "new page"
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
                        PatientMenu();
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
        static void PatientMenu()
        {
            Console.Clear();
            Console.WriteLine("==== Patient Dashboard ====");
            Console.WriteLine("1. View assigned doctor");
            Console.WriteLine("2. View room details");
            Console.WriteLine("3. View appointment schedule");
            Console.WriteLine("4. Logout");
            // Implement patient-specific functionalities here
            Console.ReadKey();
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
