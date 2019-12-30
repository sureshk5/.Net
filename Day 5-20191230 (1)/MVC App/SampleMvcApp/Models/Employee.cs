using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDalLib;
using System.Data;
namespace SampleMvcApp.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public long EmpPhone { get; set; }
        public double EmpSalary { get; set; }
    }

    class EmpDataRepository
    {
        public List<Employee> GetAllEmployees()
        {
            var com = new DaoComponent();
            var table = com.GetAllRecords();
            List<Employee> list = new List<Employee>();
            foreach(DataRow row in table.Rows)
            {
                var emp = new Employee
                {
                    EmpID = Convert.ToInt32(row[0]),
                    EmpName = row[1].ToString(),
                    EmpAddress = row[2].ToString(),
                    EmpPhone = Convert.ToInt64(row[3]),
                    EmpSalary = Convert.ToDouble(row[4])
                };
                list.Add(emp);
            }
            return list;
        }

        public Employee Find(int id)
        {
            var com = new DaoComponent();
            DataRow row = com.FindRecord(id);
            var emp = new Employee
            {
                EmpID = Convert.ToInt32(row[0]),
                EmpName = row[1].ToString(),
                EmpAddress = row[2].ToString(),
                EmpPhone = Convert.ToInt64(row[3]),
                EmpSalary = Convert.ToDouble(row[4])
            };
            return emp;
        } 

        public void Update(Employee e)
        {
            var com = new DaoComponent();
            com.UpdateRecord(e.EmpID, e.EmpName, e.EmpAddress, e.EmpPhone, e.EmpSalary);
        }

        public void InsertEmployee(Employee e)
        {
            var com = new DaoComponent();
            com.InsertRecord(e.EmpID, e.EmpName, e.EmpAddress, e.EmpPhone, e.EmpSalary);
        }
    }
}