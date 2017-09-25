using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerDetails.Entities;
using CustomerExceptions;
using System.Text.RegularExpressions;
using CustomerDrtails.DAL;



namespace CustomerDetails.BL
{
    public class CustomerBL
    {
        public static bool AddCustomerBL(Customer newCustomer)
        {
            bool customerAdded = false;
            try
            {
                if (ValidateCustomer(newCustomer))
                {
                    CustomerDAL customerDAL = new CustomerDAL();
                    customerAdded = customerDAL.AddCustomerDAL(newCustomer);
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return customerAdded;
        }




        public static int GetCustomerId()
        {
            int customerId = 0;
            try
            {
                customerId = CustomerDAL.GetCustomerId();
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return customerId;
        }





        private static bool ValidateCustomer(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            bool validCustomer = true;

            Regex ex1 = new Regex("^[a-z]+$", RegexOptions.IgnoreCase);
            if (customer.CustomerFirstName == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer FirstName Required");
            }
            else
            {
                if (!ex1.IsMatch(customer.CustomerFirstName))
                {
                    validCustomer = false;
                    sb.AppendFormat("{0}{1}", "Invalid Name", Environment.NewLine);
                }
            }



            Regex ex2 = new Regex("^[a-z]+$", RegexOptions.IgnoreCase);

            if (customer.CustomerLastName == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer LastName Required");
            }
            else
            {
                if (!ex2.IsMatch(customer.CustomerLastName))
                {
                    validCustomer = false;
                    sb.AppendFormat("{0}{1}", "Invalid Name", Environment.NewLine);
                }
            }



            if (customer.DOB >= DateTime.Now)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid DOB ");
            }



            if (customer.CustomerItems == null)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer Items are Required");
            }


            if ((customer.Gender).ToString() == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Gender is Required");
            }


            if (customer.CustomerCountry == "Select Country")
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer Country Required");
            }



            if (customer.CustomerCity == "Select City")
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer City Required");
            }


            if (customer.CustomerAddress == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer Address can not be empty");
            }


            if (customer.CustomerPhoneNumber == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid PhoneNumber(enter only 10 numbers)");
            }


            if (customer.CustomerPinCode == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid PinCode(enter only 6 numbers)");
            }


            Regex ex3 = new Regex(@"^([a-z0-9]+(\.|\*)?)+@([a-z][a-z0-9\-]+(\.|\-*\.))+[a-z]{2,6}$", RegexOptions.IgnoreCase);
            if (customer.CustomerEmailId == null)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer EmailId Required");
            }
            else
            {
                if (!ex3.IsMatch(customer.CustomerEmailId))
                {
                    validCustomer = false;
                    sb.AppendFormat("{0}{1}", "Invalid EmailId", Environment.NewLine);
                }
            }



            if (customer.CustomerListOfItems == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer ListOfItems are Required");
            }


            if (customer.CustomerTown == "Select Town")
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Please select Town");
            }


            if (customer.CustomerVillage == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Please select village");
            }


            if (customer.Products == string.Empty)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Please Select Products");
            }



            if (customer.CustomerMPTMarks == 0)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + " CustomerMPTMarks Required");
            }
            else
            {
                if (customer.CustomerMPTMarks > 100 || customer.CustomerMPTMarks < 0)
                {
                    sb.AppendFormat("{0}{1}", "enter between 0 to 100 marks", Environment.NewLine);
                }
            }



            if (customer.CustomerMTTMarks == 0)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + " CustomerMTTMarks Required");
            }
            else
            {
                if (customer.CustomerMTTMarks > 100 || customer.CustomerMTTMarks < 0)
                {
                    sb.AppendFormat("{0}{1}", "enter between 0 to 100 marks", Environment.NewLine);
                }
            }




            if (customer.CustomerAssignment == 0)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + " CustomerAssignment Required");
            }
            else
            {
                if (customer.CustomerAssignment > 100 || customer.CustomerAssignment < 0)
                {
                    sb.AppendFormat("{0}{1}", "enter between 0 to 100 marks", Environment.NewLine);
                }
            }




            if (customer.CustomerAge <= 0 || customer.CustomerAge > 100)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid Age(Enter Age inbetween 0 to 100 years )");
            }



            if (customer.CustomerBloodGroup == null)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer BloodGroup is Required");
            }






            if (sb.Length != 0)
            {
                throw new CustomerException(sb.ToString());
            }
            else
            {
                validCustomer = true;
            }
            return validCustomer;
        }



        public static List<Customer> GetAllCustomersBL()
        {
            List<Customer> customerList = null;
            try
            {
                CustomerDAL customerDAL = new CustomerDAL();
                customerList = customerDAL.GetAllCustomersDAL();
            }
            catch (CustomerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerList;
        }





        public static Customer SearchCustomerBL(int searchCustomerId)
        {
            Customer searchCustomer = null;
            try
            {
                CustomerDAL customerDAL = new CustomerDAL();
                searchCustomer = customerDAL.SearchCustomerDAL(searchCustomerId);
            }
            catch (CustomerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchCustomer;

        }


        public static bool UpdateCustomerBL(Customer updateCustomer)
        {
            bool customerUpdated = false;
            try
            {
                if (ValidateCustomer(updateCustomer))
                {
                    CustomerDAL customerDAL = new CustomerDAL();
                    customerUpdated = customerDAL.UpdateCustomerDAL(updateCustomer);
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customerUpdated;

        }



        public static bool DeleteCustomerBL(int deleteCustomerId)
        {
            bool customerDeleted = false;
            try
            {
                if (deleteCustomerId > 0)
                {
                    CustomerDAL customerDAL = new CustomerDAL();
                    customerDeleted = customerDAL.DeleteCustomerDAL(deleteCustomerId);
                }
                else
                {
                    throw new CustomerException("Invalid Customer Id");
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customerDeleted;
        }



        public static List<int> GetIds()
        {
            List<int> Ids = null;
            Ids = CustomerDAL.GetIds();
            return Ids;
        }




        public static List<string> GetCities(string country)
        {
            List<string> str = null;
            str = CustomerDAL.GetCities(country);
            return str;
        }



    }
}
























    






            
          











	
	 