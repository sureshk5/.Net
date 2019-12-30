using System;
using System.Collections;
using System.Collections.Generic;
/*
 * A Class whose object can be used in a foreach statement is called a Collection class.
 * It must implement an interface called IEnumerable.
 * IEnumerable has only one function called GetEnumerator. 
 * The function returns an IEnumerator object
 * IEnumerator has method called MoveNext() and a property called Current which is used to access the Current object in the collection while U iterate to the next... 
 * Indexer is a operator overloading of [] operator to access the element of the internal Collection using a specified index...
 */
namespace Frameworks
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }

    class BookCollection : IEnumerable<Book>
    {
        public Book this[int index]//Indexer
        {
            get
            {
                return books[index];
            }
        }
        List<Book> books = new List<Book>();
        public void AddBook(Book bk) => books.Add(bk);
        public void Delete(int id)
        {
            var book = books.Find((b) => b.BookID == id);
            if(book == null)
            {
                throw new Exception("No book found to delete");
            }
            books.Remove(book);

        }

        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }        

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int Total { get => books.Count; }
    }
    class CustomCollections
    {
        static void Main(string[] args)
        {
            BookCollection collection = new BookCollection();
            collection.AddBook(new Book { BookID = 1, Title = "Pro C#"});
            collection.AddBook(new Book { BookID = 2, Title = "2 States" });
            collection.AddBook(new Book { BookID = 3, Title = "A Suitable Boy" });
            collection.AddBook(new Book { BookID = 4, Title = "King Lear" });

            //var iterator = collection.GetEnumerator();
            //while(iterator.MoveNext())
            //    Console.WriteLine(iterator.Current.Title);
            foreach (var book in collection) Console.WriteLine(book.Title);
            Console.WriteLine("The total no of books: " + collection.Total);
            for (int i = 0; i < collection.Total; i++)
            {
                Console.WriteLine(collection[i].Title);
            }
        }
    }
}
