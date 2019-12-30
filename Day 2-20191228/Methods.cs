using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Methods are functions that are used to manipulate the data within a class of a C# Application.
 * Static methods and instance methods. Static methods are used to maintain singleton feature within the App. Instance methods are used to manipulate the instance data of the class. Usually data will be private to the class.
 * Instance methods can call the static methods but static methods need an instance of the class thro which they can call the instance methods. 
 * C# does not support global members. Static members provides the feel of the global members as they are accessed by the name of the class across the application if their scope is available. 
 * C# follows strict rules in maintaining the static and non static methods. 
 * There are 4 ways in which args can be passed into a function: ref, out, params and default.
 * ref and out are similar in the feature but ref parameters must be initialized before passsing to the function, out parameters are expected to get the values as output of the function, so no need to intialize them. however the out parameter method must set a value before returning to the caller. 
 * params are variable parameters. In this case, the no of parameters are not determined while creating the function. If U want a method to pass different no of args U can go for params. 
 */
namespace SampleConApp
{
    class Methods
    {

        static void getAllValues(int v1, int v2, ref int sum, ref int diff, ref int product, out int quotient)
        {
            sum = v1 + v2;
            diff = v1 - v2;
            product = v1 * v2;
            if (v2 != 0)
                quotient = v1 / v2;
            else
                quotient = 0;
            //The ref parameters can be modified within the function and it is reflected at the calling method. 
        }

        static string getFullName(params string [] args)
        {
            var fullName = "";
            foreach (var name in args)
            {
                fullName += name + " ";
            }
            return fullName.TrimEnd();
        }
        static void addNumbers(int[] numbers)
        {
            //Here args are passed into the function and any changes made to the args are not reflected after the function returns. This is called as passed by value..
            var sum = 0.0;
            foreach (var no in numbers)
                sum += no;
            Console.WriteLine("The sum is " + sum);
        }
        //static methods give the global feel for the user...
        static void testMethod()
        {
            Console.WriteLine("Test method");
        }
        void instanceMethod()
        {
            Console.WriteLine("Instance method");
            testMethod();//instance method is calling the static method....
        }
        static void Main(string[] args)
        {
            //static methods can call other static methods within the same class.
            // testMethod();
            // Methods cls = new Methods();
            //  cls.instanceMethod();
             addNumbers(new int[] { 123, 345, 456, 456 });
            int res1 =0, res2 =0, res3 =0, res4;
            getAllValues(123, 23, ref res1, ref res2, ref res3, out res4);
            Console.WriteLine($"The added value is {res1}\nSubtracted value is {res2}\nMultiplied value is {res3}\nDivided value is {res4}");
            getFullName("Bommathanahalli", "Nagendra", "Phaniraj");
        }
    }
}
