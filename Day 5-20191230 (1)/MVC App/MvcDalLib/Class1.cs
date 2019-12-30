using System;
using System.Data;
using System.Data.SqlClient;

namespace MvcDalLib
{
    public class DaoComponent
    {
        const string STRCONNECTION = @"Data Source=.\SQLEXPRESS;Initial Catalog=CDACTraining;Integrated Security=True";
        const string STRSELECT = "SELECT * FROM TBLEMPLOYEE";
        const string STRFIND = "SELECT * FROM TBLEMPLOYEE WHERE EMPID = @id";
        const string STRUPDATE = "UPDATE TBLEMPLOYEE SET EmpName = @name, EmpAddress = @address, EmpPhone = @phone, EmpSalary = @salary where EmpID = @id";
        const string STRINSERT = "INSERT INTO TBLEMPLOYEE VALUES(@id, @name, @address, @phone, @salary)";

        public DataTable GetAllRecords()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRSELECT, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable instance = new DataTable();
                instance.Load(reader);
                return instance;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataRow FindRecord(int id)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRFIND, con);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable instance = new DataTable();
                instance.Load(reader);
                return instance.Rows[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateRecord(int id, string name, string address, long phone, double salary)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRUPDATE, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@salary", salary);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw; 
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertRecord(int id, string name, string address, long phone, double salary)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRINSERT, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@salary", salary);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
