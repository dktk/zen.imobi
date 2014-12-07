using System.Configuration;

namespace Zen.Imobi.Web
{
    public class Config
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static readonly string RebusSubscriptionTableName = ConfigurationManager.AppSettings["Rebus.Subscriptions"];
        public static readonly string RebusSagaTable = ConfigurationManager.AppSettings["Rebus.SagaTable"];
        public static readonly string RebusSagaIndexTable = ConfigurationManager.AppSettings["Rebus.SagaIndexTable"];
    }
}