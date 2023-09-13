using HRManagementTool;

Console.WriteLine("Welcome to HR Management Tool");

bool stayInApp = true;

// check if the file exists
MenuUtilities.CheckForEmployeeFile();
MenuUtilities.LoadData();
while (stayInApp)
{
    Console.WriteLine("1. Admin login\n2. Employee login\n99. Exit application");
    string userLoginChoice = Console.ReadLine();
    switch (userLoginChoice)
    {
        case "1":
            {
                // admin login

                bool stayInAdminLogin = true;

                while (stayInAdminLogin)
                {
                    Console.WriteLine("1. Add an employee\n2. View all Employee\n3. View an Employee\n4. Update an Employee details\n5. Delete an employee\n6. Save Data\n7. Load Data\n99. Logout");
                    string userAdminMenuChoice = Console.ReadLine();

                    switch(userAdminMenuChoice)
                    {
                        case "1":
                            {
                                // add an employee
                                MenuUtilities.AddEmployee();
                                break;
                            }
                        case "2":
                            {
                                // view all employees
                                MenuUtilities.ViewAllEmployeesDetails();
                                break;
                            }
                        case "3":
                            {
                                // view a specific employee
                                MenuUtilities.ViewEmployeeDetails();
                                break;
                            }
                        case "4":
                            {
                                // update an employee details
                                MenuUtilities.UpdateEmployeeDetails();
                                break;
                            }
                        case "5":
                            {
                                //delete an employees details
                                MenuUtilities.DeleteEmployeeDetails();
                                break;
                            }
                        case "6":
                            {
                                // save data
                                MenuUtilities.SaveData();
                                break;
                            }
                        case "7":
                            {
                                // load data
                                MenuUtilities.LoadData();
                                break;
                            }
                        case "99":
                            {
                                stayInAdminLogin = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice");
                                break;
                            }
                    }
                }

                
                break;
            }
        case "2":
            {
                // employee login

                bool stayInEmployeeLogin = true;
                Employee employee;
                employee = MenuUtilities.CheckandGetEmployee();

                while (stayInEmployeeLogin)
                {
                    Console.WriteLine($"Welcome {employee.FirstName}\n1. View Details\n2. Update Details\n3. Perform Work\n4. Get Wage\n99. Log out");
                    string userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            {
                                // View details
                                MenuUtilities.DisplayEmployeeDetails(employee);
                                break;
                            }
                        case "2":
                            {
                                //update details
                                MenuUtilities.UpdateEmployeeDetails( employee );
                                break;
                            }
                        case "3":
                            {
                                //perform work
                                MenuUtilities.PerformWork(employee);
                                break;
                            }
                        case "4":
                            {
                                // get wage
                                MenuUtilities.GetWage(employee);
                                break;
                            }
                        case "99":
                            {
                                stayInEmployeeLogin = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice");
                                break;
                            }
                    }

                }

                break;
            }
        case "99":
            {
                stayInApp = false;
                break;
            }
        default:
            {
                Console.WriteLine("Invalid choice");
                break;
            }
    }

}