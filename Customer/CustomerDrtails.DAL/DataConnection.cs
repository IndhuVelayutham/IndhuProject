 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Data.Common;
 using System.Data;

namespace CustomerDetails.DAL
{
  
      public class DataConnection
    {
       public static DbCommand CreateCommand()
        {
            string dataProviderName = CustomerConfiguration.ProviderName;
            string connectionString = CustomerConfiguration.ConnectionString;
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            DbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
           return command;
        }



      
        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
          DataTable dataTable = null;
           try
            {
             command.Connection.Open();
                DbDataReader dataReader = command.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataReader.Close();
            }

            catch (DbException ex)
            {
                throw ex;
            }

            finally
            {
                
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
            return dataTable;
        }




        public static int ExecuteNonQueryCommand(DbCommand command)
        {
          int affectedRows = -1;
           try
            {
                command.Connection.Open();
                affectedRows = command.ExecuteNonQuery();

            }
            catch (DbException ex)
            {
                throw ex;
            }

            finally
            {
               if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
           
            return affectedRows;
        }




        public static object ExecuteScalarCommand(DbCommand command)
        {
          object result = null;
            try
            {
              command.Connection.Open();
              result = command.ExecuteScalar();
            }

            catch (DbException ex)
            {
                throw ex;
            }

            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
          
            return result;
        }
    }
  }

