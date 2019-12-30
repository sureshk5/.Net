using System;
/*
 * Main is the entry point for a C# program. It must be static, will be a part of a class, can take string [] as arguments which is optional Main is case sensitive. The return type could be either void or int. Main method need not be public. 
 * .NET Framework has 1000s of predefined classes that can be used to develop the .NET Applications. These classes are grouped into namespaces. U should include the namespace of the class before U use it using a keyword called 'using'. 
 * Console is a static class defined in the System namespace that represents the Console window of the Application. Using this class, U could display and take inputs from the Console Window.
 * WriteLine method is used to write a stream of text on the console output window and ReadLine is the method used to read as stream of text entered by the User on the Console window. 
 * To Compile and Execute the Program, U could press Ctrl+F5.
 * A C# File can contain multiple classes in it. There is no rule that the Main class name and the filename should be same. 
 * There are no intermediate files created in .NET. All the C# files when compiled will generate an EXE file based on the entry point file. The EXE is called as Assembly in .NET. 
 * C# Files---->Compiler-------->Assembly.
 * Assembly has 2 parts-> MS-IL(Intermediate Language) and Manifest. Manifest contains metadata of the IL code.
 * During Execution, the .NET Environment will have a component JIT Compiler which compiles the IL code to the native code specifically optimized for the executing OS. .NET performs dual compilations. One compilation by the respective language compiler and other by the .NET's executing Environment called as CLR(Common Language Runtime). CLR is a very powerfull envinroment that makes the .NET Code execute. It is the executing environment of .NET.  
 * 
 */
namespace SampleConApp
{
    class Apple
    {
        static void Main()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
