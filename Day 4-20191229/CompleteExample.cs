using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks
{
    namespace Entities
    {
        enum TravelMode { Bus, Car, Train, Bike }
        class User
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public override string ToString()
            {
                return $"{UserID},{UserName},{Password}\n";
            }
        }
        class Travel
        {
            public int TravelID { get; set; }
            public string Destination { get; set; }
            public DateTime DateOfTravel { get; set; }
            public int NoOfDays { get; set; }
            public TravelMode ModeOfTransport { get; set; }
            public string Details { get; set; }
            public User UserDetails { get; set; }
            public override string ToString()
            {
                return $"{Destination}\nDate:{DateOfTravel.ToString("dd/MM/yyyy")}\nNo Of Days:{NoOfDays}\nMode Of Transport:{ModeOfTransport}\nPosted By:{UserDetails.UserName}\nDetails:\n{Details}";
            }
        }
    }

    namespace DataLayer
    {
        using Entities;
        interface ITravelBlog
        {
            void AddTravelDetails(Travel details);
            void EditTravelInfo(Travel details);
            List<Travel> FindDetails(string destination);
            User CurrentUser { get; set; }
        }

        interface IUserLog
        {
            void RegisterNewUser(User user);
            User Login(string username, string password);
        }

        class UserLog : IUserLog
        {
            const string filename = "Users.csv";
            Dictionary<string, string> allUsers = new Dictionary<string, string>();
            public User Login(string username, string password)
            {
                fillRecords();
                if (allUsers.ContainsKey(username))
                {
                    if (allUsers[username] == password)
                        return new User { UserName = username, Password = password };
                }
                throw new Exception("Invalid Credentials");
            }

            private void fillRecords()
            {
                if (!File.Exists(filename))
                {
                    allUsers = new Dictionary<string, string>();
                    return;
                }
                allUsers.Clear();//Clear all the records in the collection...
                //It should populate all the data of the file into the Dictionary...
                var lines = File.ReadAllLines(filename);
                foreach(var line in lines)
                {
                    var words = line.Split(',');
                    allUsers[words[1]] = words[2];
                }
            }

            public void RegisterNewUser(User user)
            {
                fillRecords();
                if (allUsers.ContainsKey(user.UserName))
                    throw new Exception("User already exists");
                allUsers[user.UserName] = user.Password;
                File.AppendAllText(filename,user.ToString());
            }
        }

        class TravelBlog : ITravelBlog
        {
            private List<Travel> allData = new List<Travel>();

            public User CurrentUser { get; set; }

            public void AddTravelDetails(Travel details)
            {
                allData.Add(details);
            }

            public void EditTravelInfo(Travel details)
            {
                if (details.UserDetails.UserName != CurrentUser.UserName)
                {
                    throw new Exception("You are not authorized to edit the Details");
                }
                for (int i = 0; i < allData.Count; i++)
                {
                    if (allData[i].TravelID == details.TravelID)
                    {
                        allData[i] = details;
                        return;//Exits the function....
                    }
                }
                throw new Exception("No Details of the Travel found to edit");
            }

            public List<Travel> FindDetails(string destination)
            {
                //return allData.FindAll((t) => t.Destination == destination);
                List<Travel> tempList = new List<Travel>();
                foreach (var tr in allData)
                {
                    if (tr.Destination.Contains(destination))
                        tempList.Add(tr);
                }
                return tempList;
            }
        }
    }

    namespace UILayer
    {
        using Entities;
        using DataLayer;
        class CompleteExample
        {
            static ITravelBlog blog = new TravelBlog();

            static CompleteExample()
            {
                blog.CurrentUser = null;
            }
            static string getMenu(string filename)
            {
                string filedetails = File.ReadAllText(filename);
                return filedetails;
            }
            static void Main(string[] args)
            {
                string contents = getMenu(args[0]);
                bool processing = true;
                do
                {
                    string choice = MyConsole.GetString(contents);
                    processing = processMenu(choice);
                    clearScreen();
                } while (processing);
            }

            private static void clearScreen()
            {
                Console.WriteLine("Press any key to clear");
                Console.ReadKey();
                Console.Clear();
            }

            private static bool processMenu(string choice)
            {
                switch (choice)
                {
                    case "1":
                        loginFeature();
                        return true;
                    case "2":
                        signUpFeature();
                        return true;
                    case "3":
                        addTravelDetails();
                        return true;
                    case "4":
                    case "5":
                        searchFeature();
                        return true;
                    default:
                        return false;
                }
            }

            private static void loginFeature()
            {
                try
                {
                    string username = MyConsole.GetString("Enter the Username");
                    string password = MyConsole.GetString("Enter the password");
                    IUserLog log = new UserLog();
                    var user = log.Login(username, password);
                    blog.CurrentUser = user;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private static void signUpFeature()
            {
                int userID = MyConsole.GetNumber("Enter the UserID");
                string username = MyConsole.GetString("Enter the Username");
                string password = MyConsole.GetString("Enter the password");
                string retype = MyConsole.GetString("Retype the pasword");
                if (password != retype)
                {
                    Console.WriteLine("Password mismatch");
                    return;
                }
                try
                {
                    IUserLog log = new UserLog();
                    log.RegisterNewUser(new User { UserID = userID, UserName = username, Password = password });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); 
                }
            }

            private static void searchFeature()
            {
                string destination = MyConsole.GetString("Enter the Destination or a part of the Destination Name");
                var data = blog.FindDetails(destination);
                foreach(var tr in data)
                    Console.WriteLine(tr.ToString());
            }

            private static void addTravelDetails()
            {  if(blog.CurrentUser == null)
                {
                    Console.WriteLine("U have not logged in to Post a Travel Info");
                    Console.WriteLine("Please login to add new details");
                    return;
                }
                Travel details = new Travel();
                details.NoOfDays = MyConsole.GetNumber("Enter the No of days of Travel");
                details.ModeOfTransport = MyConsole.GetMode();
                details.DateOfTravel = MyConsole.GetDate("Enter the date as dd/MM/yyyy");
                details.Destination = MyConsole.GetString("Enter UR place of Visit");
                details.UserDetails = blog.CurrentUser;
                details.Details = MyConsole.GetString("Please enter UR Experience in the Travel to be shared to all our visitors");
                try
                {
                    blog.AddTravelDetails(details);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
