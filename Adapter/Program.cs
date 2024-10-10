using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        /// <summary>
        /// Uyumsuz arabirimleri olan nesnelerin işbirliği yapmasını sağlayan yapısal bir tasarım modelidir.
        /// </summary>        
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EdLogger());
            productManager.Save();
            Console.ReadLine();
        }        
    }

    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.Write("Logged,{0}", message);
        }
    }

    //Nuget ten indirilmiş olarak varsay
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.Write("Logged with log4Net,{0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
