using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProgram
{
    
    static class MyConsole
    {
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetNumber(string question) => int.Parse(GetString(question));

        public static double GetDouble(string question) => double.Parse(GetString(question));

        public static DateTime GetDate(string question) => DateTime.Parse(GetString(question));
        
    }
}
