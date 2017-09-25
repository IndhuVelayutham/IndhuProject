using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using LeaveLibrary.Entities;
using LeaveLibrary.Exceptions;
using System.Data;

namespace LeaveLibrary.DAL
{
    public class LeaveDAL
    {
        /// <summary>
        /// Method to add Leave Details
        /// </summary>
        /// <param name="leave">Leave Entity Object</param>
        /// <returns>True is insert Successfull</returns>
        /// 


        public static bool AddLeave(LeaveEntity leave)
        {
            bool added = false;
            string ConnectionString = ConfigurationManager.ConnectionStrings["Leave"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("INSERT INTO tblLeave(EmployeeId,StartDate,EndDate,ReasonId,Comments) values(@EmpId,@StartDate,@EndDate,@ReasonId,@Comments)", connection);

            command.Parameters.AddWithValue("@EmpId",leave.EmployeeId);
            command.Parameters.AddWithValue("@StartDate", leave.StartDate);
            command.Parameters.AddWithValue("@EndDate", leave.EndDate);
            command.Parameters.AddWithValue("@ReasonId", leave.Reason);
            command.Parameters.AddWithValue("@Comments", leave.Comments);
         try
         {
            connection.Open();
            command.Connection = connection;
            int affected = command.ExecuteNonQuery();
            if (affected > 0)
            {
                added = true;
            }
            command.Dispose();

        }
            
            catch (SqlException ex)
            {
                throw new LeaveException(ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
                }
            return added;
        }





        public static bool LoginUser(LoginEntity login)
        {
            bool success = false;
            string connectionString = ConfigurationManager.ConnectionStrings["Leave"].ConnectionString;
            SqlConnection connection=null;
            SqlCommand command=null;

            try
            {
                connection = new SqlConnection(connectionString);
                command = new SqlCommand("Select * from tblUsers", connection);
                SqlDataReader reader = command.ExecuteReader();
                connection.Open();
                int userId;
                string password;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userId = reader.GetInt32(0);
                        password = reader.GetString(1);
                        if (userId == login.UserId && password == login.Password)
                        {
                            success = true;
                            
                        }
                    }
                }
                command.Dispose();
            }
            catch (SqlException ex)
            {
                throw new LeaveException(ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
                }
            return success;
        }



        public static List<LeaveEntity> GetAllReasons()
        {
            List<LeaveEntity> reasons = null;
            
            string connectionString = ConfigurationManager.ConnectionStrings["Leave"].ConnectionString;
            SqlConnection connection = null;
            SqlCommand command = null;
            connection.Open();
            try
            {
                connection = new SqlConnection(connectionString);
                command = new SqlCommand("Select * from tblReason", connection);
                SqlDataReader reader = command.ExecuteReader();
                int userId;
                string password;

                if (reader.HasRows)
                {
                     reasons = new List<LeaveEntity>();
                    while (reader.Read())
                    {
                        LeaveEntity reason = new LeaveEntity();
                        userId = reader.GetInt32(0);
                        password = reader.GetString(1);
                    }
                }

               
            }
            catch (SqlException ex)
            {
                throw new LeaveException(ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
            
            
            return reasons;
        }
    }
}
