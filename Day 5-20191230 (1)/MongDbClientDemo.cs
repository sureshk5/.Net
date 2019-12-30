using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.CData.MongoDB;
namespace DatabaseProgram
{
    class MongDbClientDemo
    {
        static void Main(string[] args)
        {
            var con = new MongoDBConnection("Server=127.0.0.1;Port=27017;Database=cdactraining;");  
            var cmd = new MongoDBCommand("SELECT * FROM employees", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                    Console.WriteLine(reader["empName"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
