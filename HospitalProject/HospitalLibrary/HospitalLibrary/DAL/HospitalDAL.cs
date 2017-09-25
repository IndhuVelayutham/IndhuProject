using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using HospitalExceptionLayer;
using System.Configuration;
using System.Data.SqlClient;

namespace HospitalLibrary.DAL
{
    public class HospitalDAL
    {
        public string ConnectionString { get; set; }
        public HospitalDAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["HospitalConnection"].ConnectionString;
        }
        public DataTable ValidateCredential(string userName, string password)
        {
            DataTable userTable = new DataTable();
            try
            {
                using (SqlConnection loginConnection = new SqlConnection(ConnectionString))
                {
                    loginConnection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = loginConnection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_ValidateCredentials";

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@userName";
                        param.Value = userName;
                        param.DbType = DbType.String;

                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@password";
                        param.Value = password;
                        param.DbType = DbType.String;

                        command.Parameters.Add(param);

                        SqlDataReader reader = command.ExecuteReader();
                        userTable.Load(reader);
                    }
                }
            }

            catch (DbException ex)
            {
                throw new HospitalException(ex.Message);
            }

            return userTable;
        }

        internal int AddPatient(Entity.Patient patient)
        {
            int patientId = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_AddPatient";
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@PatientName";
                        param.Value = patient.Name;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PatientGender";
                        param.Value = patient.Gender;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PatientAddress";
                        param.Value = patient.Address;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PatientDOB";
                        param.Value = patient.DateOfBirth;
                        param.DbType = DbType.DateTime;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PatientContactNumber";
                        param.Value = patient.ContactNumber;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            patientId = Convert.ToInt32(dt.Rows[0]["patientId"]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new HospitalException(ex.Message);
            }
            return patientId;
        }

        internal DataTable getPatientByID(int patientID)
        {
            int patientId = 0;
            DataTable dt;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_GetPatientInfoByPatientID";
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@PatientID";
                        param.Value = patientID;
                        param.DbType = DbType.Int32;
                        command.Parameters.Add(param);

                        SqlDataReader reader = command.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(reader);
                        
                    }
                }
            }
            catch (DbException ex)
            {
                throw new HospitalException(ex.Message);
            }
            return dt;
        }
    }
}
