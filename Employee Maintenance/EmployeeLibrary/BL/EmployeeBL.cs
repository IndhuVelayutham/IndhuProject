using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeLibrary.Entities;
using System.Text.RegularExpressions;
using EmployeeLibrary.Exceptions;
using EmployeeLibrary.DAL;

namespace EmployeeLibrary.BL
{
    public class EmployeeBL
    {
        public bool AddEmployee(Employee employee)
        {
            bool employeeAdded = false;
            try
            {
                if (ValidateEmployee(employee))
                {
                    EmployeeDAL obj = new EmployeeDAL();
                    employeeAdded = obj.AddEmployee(employee);
                }
            }
            catch (EmployeeException)
            {
                throw;
            }
            return employeeAdded;
        }

        private bool ValidateEmployee(Employee employee)
        {
            bool validEmployee = false;
            Regex ex1 = new Regex(@"\d{6}");
            Regex ex2 = new Regex("[a-z]+", RegexOptions.IgnoreCase);
            StringBuilder sb = new StringBuilder();
            if (!ex1.IsMatch(employee.EmployeeId.ToString()))
            {
                sb.AppendFormat("{0}{1}", "Id should be six digits", Environment.NewLine);
            }
            if (!ex2.IsMatch(employee.EmployeeName))
            {
                sb.AppendFormat("{0}{1}", "Invalid Name", Environment.NewLine);
            }
            if (sb.ToString().Length != 0)  
                throw new EmployeeException(sb.ToString());
            else
                validEmployee = true;

            return validEmployee;
        }




        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = null;
            try
            {
                EmployeeDAL obj = new EmployeeDAL();
                employees = obj.GetAllEmployees();
            }
            catch (EmployeeException)
            {

                throw;
            }
            return employees;
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
                EmployeeDAL obj = new EmployeeDAL();
                employeeDeleted = obj.DeleteEmployee(employee);

            }
            catch (EmployeeException)
            {
                
                throw;
            }
            return employeeDeleted;
        }

        public Employee SearchEmployee(int searchId)
        {
            Employee searchEmployee = null;
            try
            {
                EmployeeDAL obj = new EmployeeDAL();
                searchEmployee = obj.SearchEmployee(searchId);
            }
            catch (EmployeeException)
            {
                
                throw;
            }
            return searchEmployee;
        }
    }
}
