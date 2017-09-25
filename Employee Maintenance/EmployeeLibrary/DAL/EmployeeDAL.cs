using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeLibrary.Entities;
using EmployeeLibrary.Exceptions;


namespace EmployeeLibrary.DAL
{
    public class EmployeeDAL
    {
        private static List<Employee> employees;

        static EmployeeDAL() 
        {
            employees = new List<Employee>();
            employees.Add(new Employee { EmployeeId = 1, EmployeeName = "Ganesh", DOJ = DateTime.ParseExact("12-SEP-2010", "dd-MMM-yyyy", null), Designation = DesignationType.Trainer });
            employees.Add(new Employee { EmployeeId = 2, EmployeeName = "Nachiket", DOJ = DateTime.ParseExact("12-DEC-2010", "dd-MMM-yyyy", null), Designation = DesignationType.Trainer });

        }
        public bool AddEmployee(Employee employee)
        {
            bool employeeAdded = false;
            try
            {
                employees.Add(employee);
                employeeAdded = true;
            }
            catch (Exception ex)
            {
                throw new EmployeeException(ex.Message);
            }
            return employeeAdded;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = null;
            try
            {
                employeeList = employees;
            }
            catch (Exception ex)
            {
                throw new EmployeeException(ex.Message); 
            }
            return employeeList;
        }

        public bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Employee employee)
        {
            bool employeeDeleted = false;
            try
            {
                employeeDeleted=employees.Remove(employee);
            }
            catch (Exception ex)
            {
                throw new EmployeeException(ex.Message);
             
            }
            return employeeDeleted;
        }

        public Employee SearchEmployee(int searchId)
        {
            Employee searchEmployee = null;
            try
            {
                searchEmployee = employees.Find(employee => employee.EmployeeId == searchId);
            }
            catch (Exception ex)
            {
                
                  throw new EmployeeException(ex.Message); 
            }
            return searchEmployee;
        }
    }
}
