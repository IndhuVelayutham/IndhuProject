using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeLibrary.Entities;
using EmployeeLibrary.BL;
using EmployeeLibrary.Exceptions;

namespace EmployeeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter choice:");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        GetAllEmployees();
                        break;
                    case 3:
                        SearchEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");

                        break;
                }
            } while (choice != -1);


        }

        private static void UpdateEmployee()
        {
            try
            {
                Employee updateEmployee = new Employee();
                Console.WriteLine("Id:");
                updateEmployee.EmployeeId = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Name:");
                updateEmployee.EmployeeName = Console.ReadLine();
                Console.WriteLine("DOJ(dd-MM-yyyy):");
                updateEmployee.DOJ = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                Console.WriteLine("Designation:");
                updateEmployee.Designation = (DesignationType)Enum.Parse(typeof(DesignationType), Console.ReadLine());

                EmployeeBL obj = new EmployeeBL();
                bool employeeUpdated = obj.UpdateEmployee(updateEmployee);

            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private static void DeleteEmployee()
        {
            try
            {

                //EmployeeBL obj = new EmployeeBL();
                
                Console.WriteLine("Enter Id:");
                int searchId = Int32.Parse(Console.ReadLine());
                EmployeeBL obj = new EmployeeBL();
                Employee employee = obj.SearchEmployee(searchId);
                bool employeeDeleted = obj.DeleteEmployee(employee);
                if (employeeDeleted)
                    Console.WriteLine("Employee Deleted");
                else
                    Console.WriteLine("Employee Not Deleted");

            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
              
            }
        }

        private static void SearchEmployee()
        {
            try
            {
                Console.WriteLine("Enter Id:");
                int searchId = Int32.Parse(Console.ReadLine());
                
                EmployeeBL obj = new EmployeeBL();
                Employee employee = obj.SearchEmployee(searchId);
                
if (employee != null)
                {
                    Console.WriteLine("{0} {1} {2} {3}", employee.EmployeeId, employee.EmployeeName, employee.DOJ.ToString("dd-MMM-yyyy"), employee.Designation.ToString());
                }
                else
                {
                    Console.WriteLine("No Employee Exists");
                }
            }
            catch (EmployeeException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void GetAllEmployees()
        {
            try
            {
                EmployeeBL obj = new EmployeeBL();
                List<Employee> employees = obj.GetAllEmployees();
                if (employees != null)
                {
                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine("{0} {1} {2} {3}",employee.EmployeeId,employee.EmployeeName,employee.DOJ.ToString("dd-MMM-yyyy"),employee.Designation.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No Employee Exists");
                }
            }
            catch (EmployeeException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void AddEmployee()
        {
            try
            {
                Employee newEmployee = new Employee();
                Console.WriteLine("Id:");
                newEmployee.EmployeeId = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Name:");
                newEmployee.EmployeeName = Console.ReadLine();
                Console.WriteLine("DOJ(dd-MM-yyyy):");
                newEmployee.DOJ = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                Console.WriteLine("Designation:");
                newEmployee.Designation = (DesignationType)Enum.Parse(typeof(DesignationType), Console.ReadLine());
                
                EmployeeBL obj = new EmployeeBL();
                bool employeeAdded = obj.AddEmployee(newEmployee);
                
                 if (employeeAdded)
                    Console.WriteLine("Employee Added");
                else
                    Console.WriteLine("Employee Not Added");

            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. GetAll Employees");
            Console.WriteLine("3. Search mployee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
        }


    }
}
