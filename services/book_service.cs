using Library.data;
using Library.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.services
{
    internal class book_service
    {
        public void ManageBooks()
        {
            while (true)
            {
                Console.WriteLine("\n==========  Book Management ==========");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. List all books");
                Console.WriteLine("3. Delete a book");
                Console.WriteLine("4. Back to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": ListBooks(); break;
                    case "3": DeleteBook(); break;
                    case "4": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
        }
        private void AddBook()
        {
            Console.WriteLine("ISSN number: ");
            string issnNumber = Console.ReadLine();

            if (library.books.Any(b => b.ISSN == issnNumber))
            {
                Console.WriteLine("This book already exists in the library");
                return;
            }


            Console.WriteLine("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Author name: ");
            string authorName = Console.ReadLine();
            Console.WriteLine("Author surname: ");
            string authorSurname = Console.ReadLine();

            Author author = library.authors.FirstOrDefault(a => a.Name == authorName && a.Surname == authorSurname);
            if(author == null)
            {
                author = new Author { Name = authorName, Surname = authorSurname };
                library.authors.Add(author);
            }

            Book book = new Book
            {
                Title = title,
                Author = author,
                ISSN = issnNumber
            };
            library.books.Add(book);
            Console.WriteLine("Book successfully added");
            Console.ReadLine();
        }
        private void ListBooks()
        {
            if (!library.books.Any())
                Console.WriteLine("There are no books");
            foreach (var book in library.books)
            {
                Console.WriteLine(book);
            }
            Console.ReadLine();
        }
        private void DeleteBook()
        {
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Wrong input");
                return;
            }

            Book book = library.books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                Console.WriteLine("A book with this id doesn't exist");
                return;
            }
            
            library.books.Remove(book);
            Console.WriteLine("Book successfully removed");
            Console.ReadLine();
        }
    }
}
