using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLib;
using System.Data;
namespace DatabaseProgram
{
    class LayeredDemo
    {
        static void Main(string[] args)
        {
            var com = new DBComponent();
            DataTable table =com.GetAllEmployees();
            foreach(DataRow row in table.Rows)
                Console.WriteLine(row["EmpName"]);
        }
    }
}
