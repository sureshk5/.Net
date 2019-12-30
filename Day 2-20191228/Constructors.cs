using System;
/*
 * Constructors have the same name of the class with parameters optional.
 * Constructors dont have any return type, not even void. 
 * Constructors can be overloaded. 
 * Constructors are explicitly invoked using new operator. new is the formal way of invoking a Constructor.
 * For initializing static members, U could use static constructors similar to the static block of Java. 
 * Static constructors cannot be parameterized, will not have access specifier and will be implicitly invoked. It will be called once and only once during the execution of the program. U will never know when the static constructor be called. 
 */
namespace SampleConApp
{
    class Infotainment
    {
        public string Name { get; set; }
        public string Navigation { get; set; }
        public string Stereo { get; set; }
        public override string ToString()
        {
            return $"{Name} uses {Navigation} while driving and U could hear good music from {Stereo}";
        }
    }
    class Car
    {
        //Constructor is used to provide data for the object creation so that we could use it immediately after its creation. Rules of the constructors are same as any other OOP language. 
        public Car(Infotainment infotainment)
        {
            Infotainment = infotainment;
        }
        public int CarNo { get; set; }
        public string CarModel { get; set; }
        public string CarMake { get; set; }
        public double CarPrice { get; set; }
        public Infotainment Infotainment { get; set; }

        public override string ToString()
        {
            return $"The Car is manufactured by {CarMake}\nThe Model name is {CarModel}\nIts Priced at {CarPrice:C}\nIts Registered No is {CarNo}.\nIt has infotainment of {Infotainment}";
        }
    }
    class Constructors
    {
        static Constructors()
        {
            Console.WriteLine("This line executes even before the Main starts");
        }
        static void Main(string[] args)
        {
            Car car = new Car(new Infotainment { Name="Harman", Navigation="Google Maps", Stereo="JBL 1000W Speakers" }){ CarNo = 7319, CarMake = "Honda", CarModel = "WRV", CarPrice = 965000 };
            Console.WriteLine(car);
        } 
    }
}
