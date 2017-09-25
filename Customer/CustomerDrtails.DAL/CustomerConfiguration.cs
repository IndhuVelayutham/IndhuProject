

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using System.Configuration;

namespace CustomerDetails.DAL
{
    public class CustomerConfiguration
    {
        private static string providerName;

        public static string ProviderName
        {
            get { return CustomerConfiguration.providerName; }
            set { CustomerConfiguration.providerName = value; }
        }
        private static string connectionString;

        public static string ConnectionString
        {
            get { return CustomerConfiguration.connectionString; }
            set { CustomerConfiguration.connectionString = value; }
        }

        static CustomerConfiguration()
        {
            providerName = ConfigurationManager.ConnectionStrings["CustomerData"].ProviderName;
            connectionString = ConfigurationManager.ConnectionStrings["CustomerData"].ConnectionString;

        }
    }
}