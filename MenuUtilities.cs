using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementTool
{
    public class MenuUtilities
    {
        public static string directory = @"D:\DOTNET\DataStoreFile\HRManagementTool\";
        public static string filename = "employee.txt";
        public static string path = $"{directory}{filename}";

        public static List<Employee> employees = new List<Employee>();

        public static void AddEmployee()
        {

            //if (employees.Count == 0)
            //{
            //    LoadData();
            //}

            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter hourly rate");
            double hourlyrate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ZIP");
            int zip = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter country");
            string country = Console.ReadLine();
            Console.WriteLine("Choose employee role");
            Console.WriteLine("1. Manager\n2. Researcher\n3. Sales Executive\n4. StoreHelper\n5. Employee");
            string employeeRoleType = Console.ReadLine();

            Employee employee = null;

            if (employeeRoleType == "1")
            {
                employee = new Manager(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "2")
            {
                employee = new Researcher(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "3")
            {
                employee = new SalesExecutive(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "4")
            {
                employee = new StoreHelper(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else
            {
                employee = new Employee(firstName, lastName, email, hourlyrate, age, zip, city, country);

            }

            employees.Add(employee);
        }

        public static void ViewAllEmployeesDetails()
        {
            if (employees.Count > 0)
            {
                foreach (Employee employee in employees)
                {
                    employee.DisplayEmployeeDetails();
                }
            }
            else
            {
                Console.WriteLine("No employees loaded");
            }


        }

        public static void ViewEmployeeDetails()
        {
            bool mailNotFound = true;
            Employee employee1 = new Employee();
            while (mailNotFound)
            {
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                foreach (Employee employee in employees)
                {
                    if (employee.Email == email)
                    {
                        employee1 = employee;
                        mailNotFound = false;
                    }
                }

                if (mailNotFound == true)
                {
                    Console.WriteLine("Invalid email");
                }

                employee1.DisplayEmployeeDetails();
            }
        }

        public static void CheckForEmployeeFile()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine("New employee file has been created");
            }
            else
            {
                Console.WriteLine("employee file is already existing");
            }
        }

        public static void SaveData()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Employee emp in employees)
            {
                sb.Append($"firstname:{emp.FirstName};");
                sb.Append($"lastname:{emp.LastName};");
                sb.Append($"email:{emp.Email};");
                sb.Append($"age:{emp.Age};");
                sb.Append($"hourlyrate:{emp.HourlyRate};");
                sb.Append($"noofhoursworked:{emp.NoOfHoursWorked};");
                sb.Append($"zip:{emp.EmployeeAddress.zipCode};");
                sb.Append($"city:{emp.EmployeeAddress.city};");
                sb.Append($"country:{emp.EmployeeAddress.country};");
                if (emp is Manager)
                {
                    sb.Append($"type:1;");
                }
                else if (emp is Researcher)
                {
                    sb.Append($"type:2;");
                }
                else if (emp is SalesExecutive)
                {
                    sb.Append($"type:3;");
                }
                else if (emp is StoreHelper)
                {
                    sb.Append($"type:4;");
                }
                else
                {
                    sb.Append($"type:5;");
                }

                if (!(emp == employees[employees.Count - 1]))
                {
                    sb.Append("*");
                }
            }
            File.WriteAllText(path, sb.ToString());
            Console.WriteLine("Data successfully saved"); ;
        }

        public static void LoadData()
        {
            employees.Clear();
            string AllEmployeeString = File.ReadAllText(path);
            string[] EmployeeDetails = AllEmployeeString.Split('*');
            foreach (string empstring in EmployeeDetails)
            {
                string[] EmployeeDetail = empstring.Split(";");
                string firstName = EmployeeDetail[0].Substring(EmployeeDetail[0].IndexOf(":") + 1);
                string lastName = EmployeeDetail[1].Substring(EmployeeDetail[1].IndexOf(":") + 1);
                string email = EmployeeDetail[2].Substring(EmployeeDetail[2].IndexOf(":") + 1);
                int age = int.Parse(EmployeeDetail[3].Substring(EmployeeDetail[3].IndexOf(":") + 1));
                double hourlyRate = double.Parse(EmployeeDetail[4].Substring(EmployeeDetail[4].IndexOf(":") + 1));
                int noOfHoursWorked = int.Parse(EmployeeDetail[5].Substring(EmployeeDetail[5].IndexOf(":") + 1));
                int zip = int.Parse(EmployeeDetail[6].Substring(EmployeeDetail[6].IndexOf(":") + 1));
                string city = EmployeeDetail[7].Substring(EmployeeDetail[7].IndexOf(":") + 1);
                string country = EmployeeDetail[8].Substring(EmployeeDetail[8].IndexOf(":") + 1);
                string type = EmployeeDetail[9].Substring(EmployeeDetail[9].IndexOf(":") + 1);

                if (type == "1")
                {
                    Employee employee = new Manager(firstName, lastName, email, hourlyRate, age, zip, city, country);
                    employee.NoOfHoursWorked = noOfHoursWorked;
                    employees.Add(employee);
                }
                else if (type == "2")
                {
                    Employee employee = new Researcher(firstName, lastName, email, hourlyRate, age, zip, city, country);
                    employee.NoOfHoursWorked = noOfHoursWorked;
                    employees.Add(employee);
                }
                else if (type == "3")
                {
                    Employee employee = new SalesExecutive(firstName, lastName, email, hourlyRate, age, zip, city, country);
                    employee.NoOfHoursWorked = noOfHoursWorked;

                    employees.Add(employee);

                }
                else if (type == "4")
                {
                    Employee employee = new StoreHelper(firstName, lastName, email, hourlyRate, age, zip, city, country);
                    employee.NoOfHoursWorked = noOfHoursWorked;

                    employees.Add(employee);
                }
                else
                {
                    Employee employee = new Employee(firstName, lastName, email, hourlyRate, age, zip, city, country);
                    employee.NoOfHoursWorked = noOfHoursWorked;

                    employees.Add(employee);
                }

            }
            Console.WriteLine("Data successfully loaded");
        }

        public static void UpdateEmployeeDetails()
        {
            bool mailNotFound = true;
            Employee employee1 = new Employee();
            while (mailNotFound)
            {
                Console.WriteLine("Enter email");
                string empEmail = Console.ReadLine();
                foreach (Employee employee3 in employees)
                {
                    if (employee3.Email == empEmail)
                    {
                        employee1 = employee3;
                        mailNotFound = false;
                    }
                }

                if (mailNotFound == true)
                {
                    Console.WriteLine("Invalid email");
                }
            }

            int empIndex = employees.IndexOf(employee1);

            Employee employee2 = new Employee();

            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter hourly rate");
            double hourlyrate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ZIP");
            int zip = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter country");
            string country = Console.ReadLine();
            Console.WriteLine("Choose employee role");
            Console.WriteLine("1. Manager\n2. Researcher\n3. Sales Executive\n4. StoreHelper\n5. Employee");
            string employeeRoleType = Console.ReadLine();

            Employee employee = null;

            if (employeeRoleType == "1")
            {
                employee = new Manager(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "2")
            {
                employee = new Researcher(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "3")
            {
                employee = new SalesExecutive(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "4")
            {
                employee = new StoreHelper(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else
            {
                employee = new Employee(firstName, lastName, email, hourlyrate, age, zip, city, country);

            }

            //employees.Add(employee);

            employees[empIndex] = employee;
            Console.WriteLine($"{employee.FirstName}'s details updated successfully\nPlease perform a save & load to view latest data");


        }

        public static Employee GetEmployee()
        {
            Employee employee1 = new Employee();

            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            foreach (Employee employee in employees)
            {
                if (employee.Email == email)
                {
                    employee1 = employee;
                }
            }

            return employee1;

        }

        public static void DeleteEmployeeDetails()
        {
            bool mailNotFound = true;
            Employee employee1 = new Employee();
            while (mailNotFound)
            {
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                foreach (Employee employee in employees)
                {
                    if (employee.Email == email)
                    {
                        employee1 = employee;
                        mailNotFound = false;
                    }
                }

                if (mailNotFound == true)
                {
                    Console.WriteLine("Invalid email");
                }
            }

            employees.Remove(employee1);
            Console.WriteLine($"{employee1.FirstName}'s details deleted successfully\nPlease perform a save & load to view latest data");

        }

        public static Employee CheckandGetEmployee()
        {
            bool notFoundEmail = true;
            Employee employee = new Employee();
            while (notFoundEmail)
            {
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();

                foreach(Employee emp in employees)
                {
                    if(emp.Email == email)
                    {
                        notFoundEmail = false;
                        employee = emp;
                    }
                }

            }
            return employee;
        }

        public static void UpdateEmployeeDetails(Employee emp)
        {
            int empIndex = employees.IndexOf(emp);

            Employee employee2 = new Employee();

            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter hourly rate");
            double hourlyrate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ZIP");
            int zip = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter country");
            string country = Console.ReadLine();
            Console.WriteLine("Choose employee role");
            Console.WriteLine("1. Manager\n2. Researcher\n3. Sales Executive\n4. StoreHelper\n5. Employee");
            string employeeRoleType = Console.ReadLine();

            Employee employee = null;

            if (employeeRoleType == "1")
            {
                employee = new Manager(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "2")
            {
                employee = new Researcher(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "3")
            {
                employee = new SalesExecutive(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else if (employeeRoleType == "4")
            {
                employee = new StoreHelper(firstName, lastName, email, hourlyrate, age, zip, city, country);
            }
            else
            {
                employee = new Employee(firstName, lastName, email, hourlyrate, age, zip, city, country);

            }

            //employees.Add(employee);

            employees[empIndex] = employee;
            Console.WriteLine($"{employee.FirstName}'s details updated successfully");

            SaveData();
            LoadData();

        }

        public static void DisplayEmployeeDetails(Employee employee)
        {
            int empIndex = employees.IndexOf(employee);

            Employee emp1 = employees[empIndex];

            emp1.DisplayEmployeeDetails();

        }

        public static void PerformWork(Employee employee)
        {
            Console.WriteLine("Enter number of hours worked");
            int noOfHoursWorked = int.Parse(Console.ReadLine());

            string email = employee.Email;
            Employee employeeFromList = new Employee();
            foreach (Employee emp in employees)
            {
                    if(emp.Email == email)
                    {
                        employeeFromList = emp;
                    }
            }

            employeeFromList.PerformWork(noOfHoursWorked);
            employees[employees.IndexOf(employeeFromList)].NoOfHoursWorked = employeeFromList.NoOfHoursWorked;
            MenuUtilities.SaveData();
            MenuUtilities.LoadData();


        }

        public static void GetWage(Employee employee)
        {
            // need to get data from the list and not from the employee instance in the program class...
            MenuUtilities.LoadData();
            string email = employee.Email;
            Employee emp1 = new Employee();

            foreach (Employee emp in employees)
            {
                if(emp.Email == email)
                {
                    emp1 = emp;
                }
            }

            int empIndex = employees.IndexOf(emp1);
            employees[empIndex].GetWage();
            employees[empIndex] = emp1;
            MenuUtilities.SaveData();
            MenuUtilities.LoadData();
        }

    }
}
