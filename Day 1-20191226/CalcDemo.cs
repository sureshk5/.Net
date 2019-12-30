using System;
namespace SampleConApp
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

    class CalcDemo
    {
        const string strMenu = "Press 1 to add\nPress 2 to subtract\nPress 3 to multiply\nPress any other key to Divide\n";//All consts in C# are implicitly static.....
        static bool processing = true;
        static void Main(string[] args)
        {
            do
            {
                string choice = MyConsole.GetString(strMenu);
                processing = processMenu(choice);
            } while (processing);
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    addOperation();
                    break;
                case "2":
                    subOperation();
                    break;
                case "3":
                    mulOperation();
                    break;
                default:
                    divOperation();
                    break;
            }
            return true;
        }

        private static void divOperation()
        {
            double v1 = MyConsole.GetDouble("Enter the first value");
            double v2 = MyConsole.GetDouble("Enter the Second value");
            double res = CalcComponent.Divide(v1, v2);
            Console.WriteLine("The Divided value is " + res);
        }

        private static void mulOperation()
        {
            double v1 = MyConsole.GetDouble("Enter the first value");
            double v2 = MyConsole.GetDouble("Enter the Second value");
            double res = CalcComponent.Product(v1, v2);
            Console.WriteLine("The Product value is " + res);
        }

        private static void subOperation()
        {
            double v1 = MyConsole.GetDouble("Enter the first value");
            double v2 = MyConsole.GetDouble("Enter the Second value");
            double res = CalcComponent.Subtract(v1, v2);
            Console.WriteLine("The Subtracted value is " + res);
        }

        private static void addOperation()
        {
            double v1 = MyConsole.GetDouble("Enter the first value");
            double v2 = MyConsole.GetDouble("Enter the Second value");
            double res = CalcComponent.Sum(v1, v2);
            Console.WriteLine("The Added value is " + res);
        }
    }

    static class CalcComponent
    {
        public static double Sum(double f1, double f2) => f1 + f2;
        public static double Subtract(double f1, double f2) => f1 - f2;
        public static double Product(double f1, double f2) => f1 * f2;
        public static double Divide(double f1, double f2) => f1 / f2;
    }
}
