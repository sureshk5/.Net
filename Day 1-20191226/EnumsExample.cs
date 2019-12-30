using System;

/*
 * Named Constants for storing integral values in the form of names rather than numbers. 
 * All Enum values could be obtained using a .NET class called Enum.
 * Enum.GetValues is used to get all the values of an Enum type.
 * Enum.Parse is used convert a string to an Enum value...
 */
namespace SampleConApp
{
    enum WeekDay {  Mon, Tue, Wed, Thu, Fri };
    class EnumsExample
    {
        static void Main(string[] args)
        {
            WeekDay startDay = WeekDay.Mon;
            WeekDay endDay = WeekDay.Fri;
            Console.WriteLine("The days of the week we work are:");
            for (int i = (int)startDay; i <= (int)endDay; i++)
            {
                
                WeekDay day = (WeekDay)i;
                Console.WriteLine(day);
            }
        }
    }
}
