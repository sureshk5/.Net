using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
//For performing JSON related operations, U should an External Nuget Package called NewtonSoft thro which U get classes to perform JSON related operations like JSON conversions and reading JSON data....
namespace Frameworks
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public override string ToString()
        {
            return $"{EmpName} from {EmpAddress}";
        }
    }
    class FileIO
    {
        static void Main(string[] args)
        {
            //readingFile();
            //var objects = readCSVFile();
            //convertToJson(objects);
            //getData("Atalanta Pyrah");
            fileWritingDemo();
        }

        private static void fileWritingDemo()
        {
            using (StreamWriter writer = new StreamWriter("Contents.txt",true))
            {
                writer.WriteLine("Apple123");
                writer.WriteLine("Apple123");
                writer.WriteLine("Apple123");
                writer.WriteLine("Apple123");
                writer.Flush();
                writer.Close();
            }
        }

        private static void getData(string v)
        {
            string jsonfile = "Data.json";
            var jsonData = File.ReadAllText(jsonfile);
            var list = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
            var tempList = list.FindAll((e) => e.EmpName == v);
            foreach(var emp in tempList)
                Console.WriteLine(emp);
        }

        private static void convertToJson(List<Employee> objects)
        {
            string content = JsonConvert.SerializeObject(objects);
            File.WriteAllText("Data.json", content);
        }

        private static List<Employee> readCSVFile()
        {
            List<Employee> employees = new List<Employee>();
            string filename = "Data.csv";
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var words = line.Split(',');
                var emp = new Employee();
                emp.EmpID = int.Parse(words[0]);
                emp.EmpName = words[1];
                emp.EmpAddress = words[2];
                employees.Add(emp);
            }
            //foreach(var emp in employees)
            //    Console.WriteLine(emp);
            return employees;
        }

        private static void readingFile()
        {
            string filename = @"C:\Phaniraj\Aug-2019\Dotnet\DotnetApps\Frameworks\FileIO.cs";
            if (!File.Exists(filename))
                Console.WriteLine("File does not exist to read");
            else
            {
                string content = File.ReadAllText(filename);
                Console.WriteLine(content);
            }
        }
    }
}
