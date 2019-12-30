using System;

namespace SampleConApp
{
    class BaseClass
    {
        public void BaseFunc()
        {
            Console.WriteLine("Base Class func");
        }
    }
    /*
     * No Multiple inheritance. 
     * No access specifier while inheriting..
     * All public members will be inherited to the derived class. 
     * All protected members will be inherited to the derived class.
     * All internal members(available within the project) will be inherited to the derived class.
     * Private members will be inaccessible to the derived class. 
     */
    class DerivedClass : BaseClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Func");
    }
    class InheritanceDemo
    {
        static void Main(string[] args)
        {
            BaseClass cls = new BaseClass();
            cls.BaseFunc();

            DerivedClass cls2 = new DerivedClass();
            cls2.BaseFunc();
            cls2.DerivedFunc();
        }
    }
}
