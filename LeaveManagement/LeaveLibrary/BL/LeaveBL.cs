using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeaveLibrary.DAL;
using LeaveLibrary.Entities;
using LeaveLibrary.Exceptions;

namespace LeaveLibrary.BL
{
    public class LeaveBL
    {
        public static bool LoginUser(LoginEntity login)
        {
            bool success = false;
            try
            {

                success = LeaveDAL.LoginUser(login);
            }
            catch(LeaveException )
            {
                throw;
            }
            return true;
        }



        public static bool AddLeave(LeaveEntity leave)
        {
            bool added = false;
            try
            {
                added =LeaveDAL.AddLeave(leave);
            }
            catch (LeaveException)
            {
                throw;
            }

            return added;

        }



        public static List<LeaveEntity> GetAllReasons()
        {
            List<LeaveEntity> reasons = null;
            try
            {
                reasons = LeaveDAL.GetAllReasons();
            }
            catch(LeaveException)
            {
                throw;
            }
            return reasons;
        }
   
    }
}
