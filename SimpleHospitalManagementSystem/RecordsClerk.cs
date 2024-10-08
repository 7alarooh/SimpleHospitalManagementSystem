using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public class RecordsClerk:Person
    {
        public int ClerkID { get; set; }

        public RecordsClerk(int clerkID, string name, int age, Gender gender, string password)
            : base(name, age, gender, password)
        {
            this.ClerkID = clerkID;
        }

    }
}
