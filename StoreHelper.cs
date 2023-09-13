using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementTool
{
    public class StoreHelper : Employee
    {
        public StoreHelper(string firstName, string lastName, string email, double hourlyRate, int age, int zip, string city, string country) : base(firstName, lastName, email, hourlyRate, age, zip, city, country)
        {
        }
    }
}
