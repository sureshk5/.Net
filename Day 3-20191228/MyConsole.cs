using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks
{
    using Entities;
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

        public static TravelMode GetMode()
        {
            Console.WriteLine("Select the Mode of Transport from the List below");
            Array allModes = Enum.GetValues(typeof(TravelMode));
            foreach (var mode in allModes) Console.WriteLine(mode);
            string value = Console.ReadLine();
            TravelMode tmode = (TravelMode)Enum.Parse(typeof(TravelMode), value);
            return tmode;
        } 
    }
}
