namespace Zen.Imobi.Web
{
    public class ApplicationConfig
    {
        public static void Start()
        {
            AutoMapperConfig.Start();
         
            BusMappings.Configure(NinjectWebCommon.Kernel);
        }
    }
}