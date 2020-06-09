using Microsoft.Extensions.Configuration;
using System.IO;

namespace MvcExample.Data
{
    public class DBContext
    {
        private static readonly object objLock = new object();
        private static DBContext instance = null;

        private IConfigurationRoot Config { get; }

        private DBContext()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Config = builder.Build();
        }

        public static DBContext GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new DBContext();
                    }
                }
            }

            return instance;
        }

        public static string GetConfig(string name)
        {
            return GetInstance().Config.GetSection(name).Value;
        }
    }
}
