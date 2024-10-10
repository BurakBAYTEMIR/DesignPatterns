using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Bu nesneleri, davranışları içeren özel sarmalayıcı nesnelerin içine yerleştirerek nesnelere yeni davranışlar eklemenizi sağlar.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "BMW", Model = "3.20", HirePrice = 2500 };

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Concrete: {0}", personalCar.HirePrice);
            Console.WriteLine("Special offer: {0}",specialOffer.HirePrice);
            Console.ReadLine();
        }

    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommericalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carbase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carbase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carbase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carbase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get 
            {  
                return _carbase.HirePrice - _carbase.HirePrice * DiscountPercentage/100; 
            }
            set 
            { 

            }
        }
    }
}
