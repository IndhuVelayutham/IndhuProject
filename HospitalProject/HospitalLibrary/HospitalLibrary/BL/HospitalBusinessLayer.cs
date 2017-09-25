using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalLibrary.Entity;
using System.Data;
using HospitalLibrary.DAL;
using HospitalExceptionLayer;

namespace HospitalLibrary.BL
{
    public class HospitalBusinessLayer
    {
        HospitalDAL dataAccessLayer;

        public HospitalBusinessLayer()
        {
            dataAccessLayer = new HospitalDAL();
        }

        public User validateCredential(string userName, string password)
        {
            User user = null;
            
            try
            {
                DataTable userTable = dataAccessLayer.ValidateCredential(userName, password);
                if (userTable != null && userTable.Rows.Count>0)
                {
                    user = new User();
                    user.Department = new Department();
                    user.FirstName = userTable.Rows[0]["firstName"].ToString();
                    user.LastName = userTable.Rows[0]["lastName"].ToString();
                    user.UserID = Convert.ToInt32(userTable.Rows[0]["userId"]);
                    user.Department.DepartmentID = Convert.ToInt32(userTable.Rows[0]["departmentId"]);
                    user.Department.DepartmentName = userTable.Rows[0]["departmentName"].ToString();
                    user.RoleID = Convert.ToInt32(userTable.Rows[0]["roleId"]);
                    user.Gender = (Gender)Enum.Parse(typeof(Gender), userTable.Rows[0]["gender"].ToString());
                }
            }
            catch(HospitalException ex)
            {
                throw ex;
            }
            
            return user;
        }

        
        public int AddPatient(Patient patient)
        {
            int patientId = 0;
            dataAccessLayer = new HospitalDAL();
            try
            {
                patientId = dataAccessLayer.AddPatient(patient);
            }
            catch (HospitalException ex)
            {
                throw ex;
            }
            return patientId;
        }

        public bool GetPatientDetailByPatientID(int patientID,out Patient patient)
        {
            patient = new Patient();
            DataTable dt;
            bool patientExist=false;
             dataAccessLayer = new HospitalDAL();
             try
             {
                 dt = dataAccessLayer.getPatientByID(patientID);
                 if (null != dt && dt.Rows.Count>0)
                 {
                     patient.Name = dt.Rows[0]["PatientName"].ToString();
                     patient.ContactNumber = dt.Rows[0]["PatientContactNumber"].ToString();
                     patient.Address = dt.Rows[0]["PatientAddress"].ToString();
                     patient.DateOfBirth = Convert.ToDateTime(dt.Rows[0]["PatientDOB"].ToString());
                     patient.Gender = (Gender)Enum.Parse(typeof(Gender), dt.Rows[0]["PatientGender"].ToString());
                     patientExist = true;
                 }
             }
             catch (HospitalException ex)
             {
                 throw ex;
             }
             return patientExist;

        }
    }
}
