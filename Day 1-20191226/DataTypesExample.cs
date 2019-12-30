using System;//Use the namespace of the classes U want to use. 
/*
 * All Data types of C# come from the .NET Framework. 
 * Data Types are classified as 2 types: Value Types and Reference types.
 * Value types are primitive types:
 * Integral: byte(Byte), short(Int16), int(Int32), long(Int64)
 * Floating: float(Single), double(Double), decimal(Decimal)
 * Other Types: bool(Boolean), char(Char), DateTime
 * User defined: Enums and Structs. 
 * Reference types are classes and value types are structs in C#. 
 * Arrays, strings and classes are all reference types. 
 * All the types have wrapper classes defined in the .NET Framework libraries.
 * These wrapper classes are used for type conversions and casting operations. 
 * The names mentioned in the braces are the .NET Type equivalents(Wrappers) of the value types. 
 */
namespace SampleConApp
{
    class DataTypesDemo
    {
        static void Main(string[] args)
        {
            //simpleConversion();
            inputExample();
        }

        private static void inputExample()
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Age");
            int Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Salary");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine($"The Name entered is {name} aged {Age} and earns a salary of {salary:C}");//New way of text format introduced in C# 6.0
        }

        private static void simpleConversion()
        {
            int value = 123;
            float fValue = 234.5F;//F is the format specifier for float, else it would be considered as double...
            double dValue = 345.56;
            Console.WriteLine($"The integer is {value}\nThe float value is {fValue} and the double value is {dValue}");
            //U could convert from one type to another using Convert class. 
            dValue = Convert.ToDouble(value);
            Console.WriteLine($"The value of dValue is {dValue}");
            //U could also use the C Style casting syntax for typecasting one value type to another. But Convert class would be prefered as it would raise an Exception if the casting fails. 
        }
    }
}