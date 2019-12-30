using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Destructors are not required in a common C# program, unless U R using some C++ code in ur App..
 * Code of C++ is called as Unmanaged Code as it executes outside the CLR. 
 * As a programmer, U cannot explicitly call a destructor of a class in C#..
 *  U could however implement an interface called IDisposable which has a method called Dispose in it. U would write the required object deletion code in that Dispose method and expect all programmers to call that method explicitly.
 */
namespace SampleConApp
{
    class SimpleClass : IDisposable
    {
        private string name;
        public SimpleClass(string name)
        {
            this.name = name;
            Console.WriteLine("OBject by name {0} is created", name);
        }
        ~SimpleClass()
        {
            Console.WriteLine("object by name {0} is destroyed", name);
        }

        public void Dispose()
        {
            Console.WriteLine("object by name {0} is destroyed", name);
            GC.SuppressFinalize(this);//It does not call the Destructor of the specified object...
        }
    }
    class DestructorsDemo
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                using (SimpleClass cls = new SimpleClass("Name:" + i))
                {
                    //using will implicitly call the Dispose method if the object goes out of scope within the using block...
                }
                //GC.Collect();//U R forcing the GC to destroy unused memory...
                //GC.WaitForPendingFinalizers();//This makes the GC not to create any new objects untill all the unused objects are removed from the memory
                //cls.Dispose();

            }
            Console.WriteLine("WoW!!!, all the objects are created");
        }
    }
}
