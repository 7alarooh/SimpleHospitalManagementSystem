using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class Login
    {
        // Dictionary to store credentials for patients and doctors
        public Dictionary<int, (string Password, string Role)> users = new Dictionary<int, (string, string)>();

        // Register a user with their ID, password, and role (either "Patient" or "Doctor")
        public void RegisterUser(int id, string password, string role)
        {
            // Validate the role
            if (role != "Patient" && role != "Doctor")
            {
                Console.WriteLine("Invalid role. Please specify either 'Patient' or 'Doctor'.");
                return;
            }

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
            if (users.TryGetValue(id, out var userInfo))
            {
                var (storedPassword, role) = userInfo;
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

