using System;

namespace SampleConApp
{
    abstract class AbstractClass
    {
        //What is abstract method? A method with no body....
        public abstract void AbstractMethod();
        public void NormalMethod()
        {
            Console.WriteLine("Normal method with implementation");
        }
    }

    class DerivedClas : AbstractClass
    {
        //override is used to implement abstract methods....
        public override void AbstractMethod()
        {
            Console.WriteLine("Derived class will implement the methods");
        }
    }
    class AbstractClasses
    {
        static void Main(string[] args)
        {
            AbstractClass cls = new DerivedClas();
            cls.AbstractMethod();//Using the base class object U call the abstract method. But the object is instantiated to the derived type...
            cls.NormalMethod();
        }
    }
}
