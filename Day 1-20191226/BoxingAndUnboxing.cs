using System;
/*
 * All data types in C# are derived from System.Object. The object is similar to void* of C++. object is a reference type. All types are implicitly convertible to object. This is called as BOXING. The value gets boxed into an object. 
 * The reconversion from the boxed type to the actual type is called as UNBOXING. 
 * Boxing is implicit and Unboxing is explicit.
 * Any type in .NET could be stored as an object, as every type is internally derived from object. Everything is object in C#.
 * If U dont know the data type of the return value of the function at compile time, it should be an object and users who consume the function will unbox the return value and perform the required operations....
 */
namespace SampleConApp
{
    class BoxingAndUnboxing
    {
        static void Main(string[] args)
        {
            object value = 123;//int is converted to object...
            int temp = (int)value;//UNBOXING. Unboxing is explicit....
            temp++;//int based operations.  
            value = temp;
            Console.WriteLine("The value is " + value);
        }
    }
}
