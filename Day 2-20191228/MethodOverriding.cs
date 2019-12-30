using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Methods of the base class must be virtual methods. 
 * virtual keyword is used to make the method overridable in derived class. 
 * override keyword is used to override the base class method. 
 * override methods cannot modify the signature of the method.
 * methods not marked as virtual will not be overridable, however U could create a new implementation of the method which will not follow the rules of Runtime Polymorphism. 
 */
namespace SampleConApp
{
    class Database
    {
        public virtual void ShowDatabase()
        {
            Console.WriteLine("The database:Sql Server" );
        }

        public void DisplayRecords()
        {
            Console.WriteLine("Displays data as Table");
        }
    }

    class NewDatabase : Database
    {
        public override void ShowDatabase()
        {
            //base.ShowDatabase();
            Console.WriteLine("The database: MongoDB");
        }
        //This is a newer implementation. The new keyword is to remove the warning and also informing the developers that this method is not related to the base version. This concept is called as Shadowing or method hiding...  
        public new void DisplayRecords()
        {
            Console.WriteLine("Displays data as JSON Collection");
        }
    }
    class MethodOverriding
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.ShowDatabase();
            db.DisplayRecords();
            db = new NewDatabase();
            db.ShowDatabase();
            db.DisplayRecords();//It still calls the base version, as the new implementation is not polymorphic....

            NewDatabase newDB = new NewDatabase();
            newDB.ShowDatabase();
            newDB.DisplayRecords();
        }   
    }
}
