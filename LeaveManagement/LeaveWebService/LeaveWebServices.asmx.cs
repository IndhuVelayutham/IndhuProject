using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using LeaveLibrary.Entities;
using LeaveLibrary.BL;
using LeaveLibrary.Exceptions;

namespace LeaveWebService
{
    /// <summary>
    /// Summary description for LeaveWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]



    public class LeaveWebServices : System.Web.Services.WebService
    {
        [WebMethod]
        public bool Addleave(LeaveEntity leave)
        {
            bool added = false;
            try
            {
                added = LeaveBL.AddLeave(leave);
            }
            catch (LeaveException ex)
            {
                CustomException(ex.GetType().ToString(), ex.Message);
            }

            return added;
        }



        [WebMethod]
        public  bool LoginUser(LoginEntity login)
        {
            bool success = false;
            try
            {

                success = LeaveBL.LoginUser(login);
            }
            catch (LeaveException ex)
            {
                CustomException(ex.GetType().ToString(), ex.Message);
            }
            return true;
        }




        [WebMethod]
         public List<LeaveEntity> GetAllReasons()
        {
            List<LeaveEntity> reasons = null;
            try
            {
                reasons = LeaveBL.GetAllReasons();
            }
            catch (LeaveException)
            {
                throw;
            }
            return reasons;
        }



        private  void CustomException(string exceptionName, string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

            XmlNode expNode = doc.CreateNode(XmlNodeType.Element, "Exception", null);
            XmlText exceptionText = doc.CreateTextNode(exceptionName);
            expNode.AppendChild(exceptionText);

            XmlNode msgNode = doc.CreateNode(XmlNodeType.Element, "Message", null);
            XmlText messageText = doc.CreateTextNode(message);
            msgNode.AppendChild(messageText);

            node.AppendChild(expNode);
            node.AppendChild(msgNode);

            throw new SoapException("Fault Occured", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, node);

        }
    }
}