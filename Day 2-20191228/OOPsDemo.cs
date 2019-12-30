using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Class in C# has methods, fields, properties, events, constructors and an optional destructor.
 * fields are the data of the class which will be usually private. 
 * properties are accessors to the fields with get(reading) and set(writing) scope.
 * methods are used to manipulate the data. Sometimes methods are replaced by properties. 
 * events are actions performed on the object: click, onMouseMove etc which is suited for Windows based GUI Components.
 * C# allows to create optional destructor which cannot be invoked explicitly but will be internally called by the CLR's Garbage Collector. 
 */
namespace SampleConApp
{
    class Book
    {
        //members are private by default in a class, similar to c++...
        int _bookId;
        string _title;
        string _author;
        double _price;
        //Property is simlar to a field but internally behaves like a function which will be invoked only when U call it. = is for set and reading will be with get...
        public int BookID
        {
            get
            {
                return _bookId;
            }
            set
            {
                _bookId = value;//value is the data set by the user using =
            }
            
        }

        public string BookTitle
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public double BookPrice
        {
            get { return _price; }
            set { _price = value; }
        }

    }

    class Employee
    {
        //id, name, address and salary...
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int EmpSalary { get; set; }
        public override string ToString()
        {
            return $"Name:{EmpName}\tAddress:{EmpAddress}\tSalary:{EmpSalary}";
        }
    }

    class Trainee
    {
        public int TraineeID { get; set; }

    }
    class OOPsDemo
    {
        static void Main(string[] args)
        {
            Book bk = new Book { BookID = 123, BookTitle = "Professional C#", Author = "Too many guys", BookPrice = 650 };
            Console.WriteLine("The best book to learn C# is {0} auhtored by {1} costing a price of {2:C}. \n{0} has a Publisher ID as {3}", bk.BookTitle, bk.Author, bk.BookPrice, bk.BookID);

            Employee emp = new Employee { EmpID = 123, EmpName = "Phaniraj", EmpAddress = "Bangalore", EmpSalary = 45000 };
            Console.WriteLine(emp);//WriteLine always implicitly converts the data to present on the console to a string version(By calling ToString()) 
        }
    }
}
