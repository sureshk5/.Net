using System;
using System.Collections.Generic;
using System.Linq;
//FCL is a part of the .NET Framework which has a large no ready to use classes to perform common operations like FileIO, Database, MultiThreading, Win32 Apps, Web Apps, Web services and many more capabilities for ur applications. With every new version of the .NET Framework U get new set of classes. These classes are grouped into namespaces. These namespaces are again grouped as DLLs. Dll is a precompiled unit which is used across multiple applications. Similar to JAR files that U see in Java. 
//Collections Framework is the very imp Framework for managing the data of the Application. In this case, the data will be always in memory of the App. However U could save the data into storage devices using other frameworks like File IO, Database, Serialization and many more. 
//Collections are of 2 types: Generic and Non Generic. Generics was introduced in .NET 2.0(2005). Earlier versions(1.0(2002) and 1.1(2003)) had only non Generic version. Currently Generics are the popular way of using Collection Classes.
//All the classes of Generics are defined under the namespace System.Collections.Gerneric.
//Important classes: List<T>, HashSet<T>, Dictionary<K,V>, Stack<T>, Queue<T>, LinkedList<T> are some of the mainly used Collection classes. 
//List is similar to Arrays but will be dynamic. Its the extension of the Non-Generic ArrayList. 
//HashSet is similar to List but will store only unique values in the collection.
//Dictionary stores the data in the form of key-value pairs where Key is unique to the collection. 
//Queue is used to store the data within the collection as First-In and First-Out.
//Stack is similar to Queue but in this case, it would be Last-In and First-Out. 
//All these classes implement certain common set of interfaces which can be used to create our own custom collections. 
//IEnumerable->ICollection->IList.
//IComparable and IComparer. 
//Most of the Collection classes will have an ability to iterate the collection. This ability comes from an Interface called IEnumerator which is obtained thro a method called GetEnumerator defined in an Interface called IEnumerable. So most of the classes of the Collections directly or indirectly implement IEnumerable interface. 
//Array is the only class that has all the features of a collection but is not the part of the Collections Framework. 
namespace Frameworks
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public long CustomerPhone { get; set; }

        public override int GetHashCode()
        {
            return CustomerID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Customer)
            {
                Customer temp = obj as Customer;
                return temp.CustomerID == this.CustomerID;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{CustomerName} available at {CustomerPhone}";
        }
    }

    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Name} is priced at {Price:C}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //listExample();
            //hashSetExample();
            //hashsetOnObjects();
            //DictionaryExample();
            //queueExample();
           
        }

        private static void queueExample()
        {
            List<Product> repository = new List<Product>();
            repository.Add(new Product { ProductID = 1, Name = "Onions", Price = 145 });
            repository.Add(new Product { ProductID = 2, Name = "Tomatoes", Price = 25 });
            repository.Add(new Product { ProductID = 3, Name = "Potatoes", Price = 35 });
            repository.Add(new Product { ProductID = 4, Name = "Brinjals", Price = 45 });
            repository.Add(new Product { ProductID = 5, Name = "Capsicum", Price = 50 });
            repository.Add(new Product { ProductID = 6, Name = "Green Chillies", Price = 100 });
            Queue<Product> recentlyViewedItems = new Queue<Product>();
            do
            {
                foreach (var item in repository) Console.WriteLine(item.Name);
                Console.WriteLine("Select the Item from the List above");
                string itemName = Console.ReadLine();
                if (recentlyViewedItems.Count == 5)
                    recentlyViewedItems.Dequeue();//Removes the first element in the queue.
                foreach(var item in repository)
                {
                    if (item.Name.Contains(itemName))
                        recentlyViewedItems.Enqueue(item);
                }
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("UR Recently Viewed Items:");
                var data = recentlyViewedItems.Reverse();
                foreach(var item in data)
                    Console.WriteLine(item);
                Console.WriteLine("Press any key to clear the screen");
                Console.ReadKey();
                Console.Clear();

            } while (true);
        }

        private static void DictionaryExample()
        {
            Dictionary<int, string> users = new Dictionary<int, string>();
            users[123] = "Phaniraj";//Adds the pair to the Dictionary, if the key exists it replaces the value...
            if (users.ContainsKey(123))//Check if the key exists
            {
                Console.WriteLine("Key exists");
            }
            users.Add(124, "Suresh");//If the Key exists, it throws an Exception called ArgumentException. 
            users[123] = "Gopal";
            users[123] = "Kumar";
            users[123] = "Vinod";
            users[123] = "Ram";
            Console.WriteLine($"The value at 123 is {users[123]}");
            foreach (var pair in users)
            {
                Console.WriteLine($"Key:{pair.Key}\tValue:{pair.Value}");
            }
        }

        private static void hashsetOnObjects()
        {
            HashSet<Customer> _all = new HashSet<Customer>();
            _all.Add(new Customer { CustomerID = 123, CustomerName = "Phaniraj", CustomerPhone = 23424234 });
            _all.Add(new Customer { CustomerID = 123, CustomerName = "Phaniraj", CustomerPhone = 23424234 });
            _all.Add(new Customer { CustomerID = 123, CustomerName = "Phaniraj", CustomerPhone = 23424234 });
            Console.WriteLine("The total no of customers are " + _all.Count);
            foreach (var cst in _all) Console.WriteLine(cst);
            var list = _all.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].CustomerName);
            }
        }

        private static void hashSetExample()
        {
            HashSet<string> basket = new HashSet<string>();
            basket.Add("Apple");//The Add method returns bool to determine whether insertion was successfull or not...
            if (basket.Add("Apple"))
                Console.WriteLine("Yes, it was added");
            else
                Console.WriteLine("No Duplicates are allowed");
            basket.Add("PineApple");
            basket.Add("CustardApple");
            basket.Add("OotyApple");
            Console.WriteLine("The total no items in the basket is " + basket.Count);
        }

        private static void listExample()
        {
            List<string> fruits = new List<string>();
            fruits.Add("Apple");//Adds the element to the bottom of the list...
            fruits.Add("PineApple");
            fruits.Add("Custartd Apple");
            fruits.Add("Ooty Apple");
            fruits.Add("Kashmir Apple");
            fruits.Insert(3, "Mango");
            fruits.Add("Washington Apple");
            fruits.Remove("Apple");//Bool to determine whether the removal was sucessfull or not..
            Console.WriteLine(fruits.Count + " is the total no of elements in the List");
            for (int i = 0; i < fruits.Count; i++)
            {
                Console.WriteLine(fruits[i]);
            }
            Console.WriteLine("Iterating thro foreach");
            foreach (var item in fruits) Console.WriteLine(item);
        }
    }
}
