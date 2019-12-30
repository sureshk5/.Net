using System;
/*
 * Interfaces are similar to abstract classes but has only abstract methods. 
 * Methods are always public and U cannot have access specifier. 
 * Class that implement the interface must implement all the methods of the interface. 
 * Multiple interfaces can be implemented at the same level. 
 * The class that implement the interface must provide public defn of the methods.
 * Methods of the interface can be implemented either implicitly or explicitly.
 */
 /*
  * LEARN IT URSELF:
  * Sealed Classes and Sealed Methods. 
  */
namespace SampleConApp
{
    interface IEmployee
    {
        void Create(int id, string name, string address);
    }

    interface ICustomer
    {
        void Create(int id, string name, string address);
    }

    class Employee : IEmployee
    {
        public void Create(int id, string name, string address)
        {
            Console.WriteLine("Employee is created and added to the Employee Database");
        }
    }

    class Customer : ICustomer
    {
        public void Create(int id, string name, string address)
        {
            Console.WriteLine("Customer is created and added to Customer database");
        }
    }

    class EmployeeCustomer : IEmployee, ICustomer
    {
        void ICustomer.Create(int id, string name, string address)
        {
            Console.WriteLine("Customer created for Customer db");
        }

        void IEmployee.Create(int id, string name, string address)
        {
            Console.WriteLine("Employee created for Employee db");
        }

        public void Create(int id, string name, string address)
        {
            Console.WriteLine("Employee-Customer is created for EmpCustomer DB");
        }
    }
    //interface ISimple
    //{
    //    void testFunc();
    //}
    //interface IExample
    //{
    //    void exampleFunc();
    //    void testFunc();
    //}

    //class SimpleClass : ISimple, IExample
    //{
    //    int x;
    //    public void exampleFunc()
    //    {
    //        Console.WriteLine(x);
    //        Console.WriteLine("Example Func");
    //    }

    //    public void testFunc()
    //    {
    //        x = 123;
    //        Console.WriteLine("testFunc");
    //    }
    //}
    class InterfacesDemo
    {
        static void Main(string[] args)
        {
            //ISimple simple = new SimpleClass();
            //simple.testFunc();

            //IExample example = new SimpleClass();
            //example.exampleFunc();

            //example = (IExample)simple;//U dont need to create the object again
            //example.exampleFunc();
            //example.testFunc();

            IEmployee emp = new EmployeeCustomer();
            emp.Create(123, "TestName", "Test Address");

            ICustomer cst = new EmployeeCustomer();
            cst.Create(123, "TestName", "Test Address");

            EmployeeCustomer empCst = new EmployeeCustomer();
            empCst.Create(123, "TestName", "Test Address");
        }
    }
}
