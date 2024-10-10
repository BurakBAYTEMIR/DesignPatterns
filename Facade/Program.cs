using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    /// <summary>
    /// Bir kütüphaneye, çerçeveye veya diğer karmaşık sınıflara basitleştirilmiş bir arayüz sağlar.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Check");
        }
    }

    interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CrossCuttongConcernsFacade _concerns;

        public CustomerManager()
        {
            _concerns = new CrossCuttongConcernsFacade();
        }
        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
            Console.WriteLine("Saved");
        }

        class CrossCuttongConcernsFacade
        {
            public ILogging Logging;
            public ICaching Caching;
            public IAuthorize Authorize;

            public CrossCuttongConcernsFacade()
            {
                Logging = new Logging();
                Caching = new Caching();
                Authorize = new Authorize();
            }
        }
    }
}
