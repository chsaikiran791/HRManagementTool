using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementTool
{
    public class Employee
    {
        // necessary properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public double HourlyRate { get; set; }

        public int NoOfHoursWorked { get; set; }

        public double Wage { get; set; }

        public Address EmployeeAddress { get; set; }

        // constructors
        public Employee()
        {

        }

        public Employee(string firstName, string lastName, string email, double hourlyRate, int age, int zip, string city, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Age = age;
            this.HourlyRate = hourlyRate;
            Address address = new Address() { zipCode = zip, city = city, country = country};
            this.EmployeeAddress = address;
        }

        // methods
        public void PerformWork(int noOfHoursWorked = 1) => NoOfHoursWorked += noOfHoursWorked;

        public void DisplayEmployeeDetails() => Console.WriteLine($"First Name: {FirstName}\nLast Name: {LastName}\nEmail: {Email}\nAge: {Age}\nZIP Code: {EmployeeAddress.zipCode}\nCity: {EmployeeAddress.city}\nCountry: {EmployeeAddress.country}");

        public void GetWage()
        {
            double Wage = NoOfHoursWorked * HourlyRate;
            Console.WriteLine($"You've worked for {NoOfHoursWorked} and your hourly rate is {HourlyRate}, so your wage is {Wage}");
            NoOfHoursWorked = 0;
        }
    }
}
