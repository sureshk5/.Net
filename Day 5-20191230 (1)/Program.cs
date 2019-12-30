using System;
using System.Data;//Classes for all kinds of data access
using System.Data.SqlClient;//Classes for SQL server databases. 
/*
 * ADO.NET is a framework for database programming in .NET Applications. 
 * It comes in 2 flavors: Connected Model and Disconnected Model.
 * Connected Model is for desktop based Apps and disconnected model is for Web based Apps where scalability is the main concern. 
 * In Connected Model, any interaction with the database will happen thro the Opening of the DB Connection and will be closed after the activity is completed. 
 * In Disconnected model, the data will be pushed into a Table object grouped inside a DataSet and interactions will happen with the tables of the dataset. There will be no Connectivity while U interact with the dataset. This is called as Disconnected Model. This is suited for web based programs where apps dont need to connect to the database while the app is running. Also scalability of the App matters.
 * ADO.NET gives a set of interfaces and Classes to interact with different kinds of Databases. 
 * All classes must implement certain interfaces:
 * Connection: A Class that makes connectivity to the database using Connection String. It has methods like Open and Close which is used to Open the Connectivity to the database and Close the Connection after the work is done(IDBConnection). 
 * Command: Is used to execute the SQL Commands thro the Connection to the database. There may be DML(INSERT, DELETE, UPDATE) and DDL(SELECT) Operations. Reading of the data happens only for SELECT Statements(IDBCommand)
 * DataReader: A reader object is required to read the data that is acquired from the database using a SELECT Query. The DataReader is a Read only and forward only reading cursor which reads each row at a time. (IDBDataReader).
 * Every Database Vendor creates a set of classes that implements these interfaces and publishes it to the developers to use their databases in .NET Apps.
 * 
 * 
 */
namespace DatabaseProgram
{
    class Program
    {
        const string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=CDACTraining;Integrated Security=True";
        const string strSelect = "SELECT * FROM TBLEMPLOYEE";
        const string strInsert = "Insert into tblEmployee values(@id, @name, @address, @phone, @salary)";//Similar to Prepared Statement of JDBC...
        static void Main(string[] args)
        {
            //readRecords();
            //insertRecord();
            insertUsingSP();
        }

        private static void insertUsingSP()
        {
            int id = MyConsole.GetNumber("Enter the ID");
            string name = MyConsole.GetString("Enter the name");
            string address = MyConsole.GetString("Enter the Address");
            long phone = long.Parse(MyConsole.GetString("Enter the Phone"));
            double salary = MyConsole.GetDouble("Enter the Salary");
            /////////////////////ADO.NET CODE///////////////////////
            /*
             * create the connection
             * create the command
             * associate the SP
             * set the parameter values
             * open the connection
             * execute the query
             * close the connection
             * handle exceptions if any
             */
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand("InsertEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private static void insertRecord()
        {
            int id = MyConsole.GetNumber("Enter the ID");
            string name = MyConsole.GetString("Enter the name");
            string address = MyConsole.GetString("Enter the Address");
            long phone = long.Parse(MyConsole.GetString("Enter the Phone"));
            double salary = MyConsole.GetDouble("Enter the Salary");
            //////////////////ADO Insertion code/////////
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                using (SqlCommand cmd = new SqlCommand(strInsert, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();//Use this for non select statements...
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("insertion failed");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        private static void readRecords()
        {
            IDbConnection con = new SqlConnection(strConnection);
            IDbCommand cmd = new SqlCommand(strSelect, ((SqlConnection)con));
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine(reader["EmpName"]);
            }
            catch (SqlException)
            {
                Console.WriteLine("OOPS! Something wrong happened");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
