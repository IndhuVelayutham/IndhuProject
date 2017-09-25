using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using CustomerExceptions;
using System.Configuration;
using CustomerDetails.Entities;
using CustomerDetails.DAL;


namespace CustomerDrtails.DAL
{
    public class CustomerDAL
    {
        public static int GetCustomerId()
        {
            int customerId = 0;
            SqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CustomerData"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandText = "usp_GetCustomerId";
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Connection = connection;

                DbParameter param = selectCommand.CreateParameter();
                param.ParameterName = "@CustomerId";
                param.DbType = DbType.Int32;
                param.Direction = ParameterDirection.Output;
                selectCommand.Parameters.Add(param);
                selectCommand.ExecuteNonQuery();
                customerId = (int)param.Value;
            }
            catch (DbException ex)
            {
                throw new CustomerException(ex.Message);
            }
            return customerId;
        }






        public bool AddCustomerDAL(Customer newCustomer)
        {
            bool customerAdded = false;
            SqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CustomerData"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandText = "uspAddCustomer";
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Connection = connection;


                selectCommand.Parameters.AddWithValue("@CustomerId", newCustomer.CustomerId);
                selectCommand.Parameters.AddWithValue("@CustomerFirstName", newCustomer.CustomerFirstName);
                selectCommand.Parameters.AddWithValue("@CustomerLastName", newCustomer.CustomerLastName);
                selectCommand.Parameters.AddWithValue("@DOB", newCustomer.DOB);
                selectCommand.Parameters.AddWithValue("@CustomerItems", newCustomer.CustomerItems);
                selectCommand.Parameters.AddWithValue("@Gender", newCustomer.Gender.ToString());
                selectCommand.Parameters.AddWithValue("@CustomerCountry", newCustomer.CustomerCountry);
                selectCommand.Parameters.AddWithValue("@CustomerCity", newCustomer.CustomerCity);
                selectCommand.Parameters.AddWithValue("@CustomerAddress", newCustomer.CustomerAddress);
                selectCommand.Parameters.AddWithValue("@CustomerPhoneNumber", newCustomer.CustomerPhoneNumber);
                selectCommand.Parameters.AddWithValue("@CustomerPinCode", newCustomer.CustomerPinCode);
                selectCommand.Parameters.AddWithValue("@CustomerEmailId", newCustomer.CustomerEmailId);
                selectCommand.Parameters.AddWithValue("@CustomerListOfItems", newCustomer.CustomerListOfItems);
                selectCommand.Parameters.AddWithValue("@CustomerTown ", newCustomer.CustomerTown);
                selectCommand.Parameters.AddWithValue("@CustomerVillage", newCustomer.CustomerVillage);
                selectCommand.Parameters.AddWithValue("@Products ", newCustomer.Products);
                selectCommand.Parameters.AddWithValue("@CustomerMPTMarks", newCustomer.CustomerMPTMarks);
                selectCommand.Parameters.AddWithValue("@CustomerMTTMarks", newCustomer.CustomerMTTMarks);
                selectCommand.Parameters.AddWithValue("@CustomerAssignment ", newCustomer.CustomerAssignment);
                selectCommand.Parameters.AddWithValue("@CustomerTotalMarks ", newCustomer.CustomerTotalMarks);
                selectCommand.Parameters.AddWithValue("@CustomerGrade ", newCustomer.CustomerGrade);
                selectCommand.Parameters.AddWithValue("@CustomerAge", newCustomer.CustomerAge);
                selectCommand.Parameters.AddWithValue("@CustomerBloodGroup ", newCustomer.CustomerBloodGroup.ToString());


                int affectedRows = selectCommand.ExecuteNonQuery();
                if (affectedRows > 0)
                    customerAdded = true;

                selectCommand.Dispose();
            }
            catch (SqlException ex)
            {
                throw new CustomerException(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return customerAdded;
        }







        public List<Customer> GetAllCustomersDAL()
        {
            List<Customer> customerList = null;
            try
            {
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspGetAllCustomers";

                DataTable dataTable = DataConnection.ExecuteSelectCommand(command);
                if (dataTable.Rows.Count > 0)
                {
                    customerList = new List<Customer>();
                    for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; rowCounter++)
                    {
                        Customer customer = new Customer();
                        customer.CustomerId = (int)dataTable.Rows[rowCounter][0];
                        customer.CustomerFirstName = (string)dataTable.Rows[rowCounter][1];
                        customer.CustomerLastName = (string)dataTable.Rows[rowCounter][2];
                        customer.DOB = (DateTime)dataTable.Rows[rowCounter][3];
                        customer.CustomerItems = (string)dataTable.Rows[rowCounter][4];
                        customer.Gender = (GenderType)Enum.Parse(typeof(GenderType), (string)dataTable.Rows[rowCounter][5]);
                        customer.CustomerCountry = (string)dataTable.Rows[rowCounter][6];
                        customer.CustomerCity = (string)dataTable.Rows[rowCounter][7];
                        customer.CustomerAddress = (string)dataTable.Rows[rowCounter][8];
                        customer.CustomerPhoneNumber = (string)dataTable.Rows[rowCounter][9];
                        customer.CustomerPinCode = (string)dataTable.Rows[rowCounter][10];
                        customer.CustomerEmailId = (string)dataTable.Rows[rowCounter][11];
                        customer.CustomerListOfItems = (string)dataTable.Rows[rowCounter][13];
                        customer.CustomerTown = (string)dataTable.Rows[rowCounter][12];
                        customer.CustomerVillage = (string)dataTable.Rows[rowCounter][14];
                        customer.Products = (string)dataTable.Rows[rowCounter][15];
                        customer.CustomerMPTMarks = (int)dataTable.Rows[rowCounter][16];
                        customer.CustomerMTTMarks = (int)dataTable.Rows[rowCounter][17];
                        customer.CustomerAssignment = (int)dataTable.Rows[rowCounter][19];
                        customer.CustomerTotalMarks = (int)dataTable.Rows[rowCounter][18];
                        customer.CustomerGrade = (string)dataTable.Rows[rowCounter][20];
                        customer.CustomerAge = (int)dataTable.Rows[rowCounter][21];
                        customer.CustomerBloodGroup = (CustomerBloodGroupType)Enum.Parse(typeof(CustomerBloodGroupType), (string)dataTable.Rows[rowCounter][22]);
                        customerList.Add(customer);
                    }
                }
            }
            catch (DbException ex)
            {
                throw new CustomerException(ex.Message);
            }
            return customerList;
        }







        public Customer SearchCustomerDAL(int searchCustomerId)
        {
            Customer searchCustomer = null;
            try
            {
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspSearchCustomer";

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@CustomerId";
                param.DbType = DbType.Int32;
                param.Value = searchCustomerId;
                command.Parameters.Add(param);

                DataTable dataTable = DataConnection.ExecuteSelectCommand(command);
                if (dataTable.Rows.Count > 0)
                {

                    searchCustomer = new Customer();
                    searchCustomer.CustomerId = (int)dataTable.Rows[0][0];
                    searchCustomer.CustomerFirstName = (string)dataTable.Rows[0][1];
                    searchCustomer.CustomerLastName = (string)dataTable.Rows[0][2];
                    searchCustomer.DOB = (DateTime)dataTable.Rows[0][3];
                    searchCustomer.CustomerItems = (string)dataTable.Rows[0][4];
                    searchCustomer.Gender = (GenderType)Enum.Parse(typeof(GenderType), (string)dataTable.Rows[0][5]);
                    searchCustomer.CustomerCountry = (string)dataTable.Rows[0][6];
                    searchCustomer.CustomerCity = (string)dataTable.Rows[0][7];
                    searchCustomer.CustomerAddress = (string)dataTable.Rows[0][8];
                    searchCustomer.CustomerPhoneNumber = (string)dataTable.Rows[0][9];
                    searchCustomer.CustomerPinCode = (string)dataTable.Rows[0][10];
                    searchCustomer.CustomerEmailId = (string)dataTable.Rows[0][11];
                    searchCustomer.CustomerListOfItems = (string)dataTable.Rows[0][12];
                    searchCustomer.CustomerTown = (string)dataTable.Rows[0][13];
                    searchCustomer.CustomerVillage = (string)dataTable.Rows[0][14];
                    searchCustomer.Products = (string)dataTable.Rows[0][15];
                    searchCustomer.CustomerMPTMarks = (int)dataTable.Rows[0][16];
                    searchCustomer.CustomerMTTMarks = (int)dataTable.Rows[0][17];
                    searchCustomer.CustomerAssignment = (int)dataTable.Rows[0][18];
                    searchCustomer.CustomerTotalMarks = (int)dataTable.Rows[0][19];
                    searchCustomer.CustomerGrade = (string)dataTable.Rows[0][20];
                    searchCustomer.CustomerAge = (int)dataTable.Rows[0][21];
                    searchCustomer.CustomerBloodGroup = (CustomerBloodGroupType)Enum.Parse(typeof(CustomerBloodGroupType), (string)dataTable.Rows[0][22]);
                }
            }
            catch (DbException ex)
            {
                throw new CustomerException(ex.Message);
            }
            return searchCustomer;
        }








        public bool UpdateCustomerDAL(Customer updateCustomer)
        {
            bool customerUpdated = false;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspUpdateCustomer";

                selectCommand.Parameters.AddWithValue("@CustomerId", updateCustomer.CustomerId);
                selectCommand.Parameters.AddWithValue("@CustomerFirstName", updateCustomer.CustomerFirstName);
                selectCommand.Parameters.AddWithValue("@CustomerLastName", updateCustomer.CustomerLastName);
                selectCommand.Parameters.AddWithValue("@DOB", updateCustomer.DOB);
                selectCommand.Parameters.AddWithValue("@CustomerItems", updateCustomer.CustomerItems);
                selectCommand.Parameters.AddWithValue("@Gender", updateCustomer.Gender.ToString());
                selectCommand.Parameters.AddWithValue("@CustomerCountry", updateCustomer.CustomerCountry);
                selectCommand.Parameters.AddWithValue("@CustomerCity", updateCustomer.CustomerCity);
                selectCommand.Parameters.AddWithValue("@CustomerAddress", updateCustomer.CustomerAddress);
                selectCommand.Parameters.AddWithValue("@CustomerPhoneNumber", updateCustomer.CustomerPhoneNumber);
                selectCommand.Parameters.AddWithValue("@CustomerPinCode", updateCustomer.CustomerPinCode);
                selectCommand.Parameters.AddWithValue("@CustomerEmailId", updateCustomer.CustomerEmailId);
                selectCommand.Parameters.AddWithValue("@CustomerListOfItems", updateCustomer.CustomerListOfItems);
                selectCommand.Parameters.AddWithValue("@CustomerTown ", updateCustomer.CustomerTown);
                selectCommand.Parameters.AddWithValue("@CustomerVillage", updateCustomer.CustomerVillage);
                selectCommand.Parameters.AddWithValue("@Products ", updateCustomer.Products);
                selectCommand.Parameters.AddWithValue("@CustomerMPTMarks", updateCustomer.CustomerMPTMarks);
                selectCommand.Parameters.AddWithValue("@CustomerMTTMarks", updateCustomer.CustomerMTTMarks);
                selectCommand.Parameters.AddWithValue("@CustomerAssignment ", updateCustomer.CustomerAssignment);
                selectCommand.Parameters.AddWithValue("@CustomerTotalMarks ", updateCustomer.CustomerTotalMarks);
                selectCommand.Parameters.AddWithValue("@CustomerGrade ", updateCustomer.CustomerGrade);
                selectCommand.Parameters.AddWithValue("@CustomerAge", updateCustomer.CustomerAge);
                selectCommand.Parameters.AddWithValue("@CustomerBloodGroup ", updateCustomer.CustomerBloodGroup.ToString());



                int affectedRows = DataConnection.ExecuteNonQueryCommand(command);

                if (affectedRows > 0)
                    customerUpdated = true;
            }
            catch (DbException ex)
            {
                throw new CustomerException(ex.Message);
            }
            return customerUpdated;

        }









        public bool DeleteCustomerDAL(int deleteCustomerId)
        {
            bool customerDeleted = false;
            try
            {
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspDeleteCustomer";

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@CustomerId";
                param.DbType = DbType.Int32;
                param.Value = deleteCustomerId;
                command.Parameters.Add(param);

                int affectedRows = DataConnection.ExecuteNonQueryCommand(command);

                if (affectedRows > 0)
                    customerDeleted = true;
            }
            catch (DbException ex)
            {
                throw new CustomerException(ex.Message);
            }
            return customerDeleted;

        }






        public static List<int> GetIds()
        {
            List<int> Ids = null;
            string command = ConfigurationManager.ConnectionStrings["CustomerData"].ConnectionString;
            SqlConnection con = new SqlConnection(command);
            con.Open();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = "uspGetIds";
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Connection = con;

            DbDataReader dr = selectCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Ids = new List<int>();
            if (dt.Rows.Count > 0)
            {
                for (int rowCounter = 0; rowCounter < dt.Rows.Count; rowCounter++)
                {
                    Ids.Add((int)dt.Rows[rowCounter][0]);
                }


            }

            return Ids;

        }


        public static List<string> GetCities(string country)
        {

            List<string> str = null;
            DbCommand command = DataConnection.CreateCommand();
            command.CommandText = "uspGetCountryId";
            DbParameter param = command.CreateParameter();
            param.ParameterName = "@CountryName";
            param.DbType = DbType.String;
            param.Value = country;
            command.Parameters.Add(param);

            int Id = (int)DataConnection.ExecuteScalarCommand(command);


            string command1 = ConfigurationManager.ConnectionStrings["CustomerData"].ConnectionString;
            SqlConnection con = new SqlConnection(command1);
            con.Open();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = "uspGetCities";
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Connection = con;
            selectCommand.Parameters.AddWithValue("@Id", Id);

            DbDataReader dr = selectCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            str = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int rowCounter = 0; rowCounter < dt.Rows.Count; rowCounter++)
                {
                    str.Add((string)dt.Rows[rowCounter][0]);
                }


            }
            return str;
        }

    }
}
