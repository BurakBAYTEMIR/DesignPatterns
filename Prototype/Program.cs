using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    /// <summary>
    /// Başka bir benzer örnekten yeni bir nesne örneği oluşturup ve ardından oluşturduğu nesneyi gereksinimlerimize göre değiştirebilir.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { FistName = "Engin", LastName = "Demiroğ", City = "Ankara", Id = 1 };

            Customer customer2 = (Customer) customer1.Clone();
            customer2.FistName = "Salih";

            Console.WriteLine(customer1.FistName);
            Console.WriteLine(customer2.FistName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public string Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }


}
