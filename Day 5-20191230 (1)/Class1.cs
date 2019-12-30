using System;
using System.Data;
using System.Data.SqlClient;
//Dlls are pre-compiled Components that are designed to be used across multiple projects and languages. Dlls are built, refered in EXE projects and consumed in it. 
//ClassLibrary is used to create the DLL.
//Dll Classes are used across multiple projects, U should make the class as public. Else it would be internal and will be available only within the project that owns it. 
namespace DataAccessLib
{
    public interface IDBComponent
    {
        void InsertEmployee(int id, string name, string address, long phone, double salary);
        void UpdateEmployee(int id, string name, string address, long phone, double salary);
        void DeleteEmployee(int id);
        DataTable GetAllEmployees();
    }

    public class DBComponent : IDBComponent
    {
        const string strConnection =@"Data Source=.\SQLEXPRESS;Initial Catalog=CDACTraining;Integrated Security=True";
        const string strSELECT = "SELECT * FROM TBLEMPLOYEE";
        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllEmployees()
        {
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(strSELECT, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("No rows found to UR records");
                }
                DataTable table = new DataTable("Table1");
                table.Load(reader);//Load fills the data and the schema of the reader into the table object...
                return table;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertEmployee(int id, string name, string address, long phone, double salary)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(int id, string name, string address, long phone, double salary)
        {
            throw new NotImplementedException();
        }
    }
}
