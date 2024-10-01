using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    internal class Login
    {
        // Dictionary to store credentials for patients and doctors
        private Dictionary<int, (string Password, string Role)> users = new Dictionary<int, (string, string)>();
        
        //the Role represents the type of user that is logging in—whether they are a Patient or a Doctor.

        // Register a user with their ID, password, and role (either "Patient" or "Doctor")
        public void RegisterUser(int id, string password, string role)
        {
            if (!users.ContainsKey(id))
            {
                users[id] = (password, role);
                Console.WriteLine($"{role} with ID {id} has been registered successfully.");
            }
            else
            {
                Console.WriteLine($"User with ID {id} already exists.");
            }
        }

        // Log in a user using their ID and password
        public string LoginUser(int id, string password)
        {
            if (users.ContainsKey(id))
            {
                var (storedPassword, role) = users[id];
                if (storedPassword == password)
                {
                    return role;  // Return role on successful login
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
            else
            {
                Console.WriteLine("User ID not found.");
            }
            return null;  // Return null if login fails
        }
    }
}
