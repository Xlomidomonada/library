using Library.data;
using Library.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Library.services
{
    internal class rental_service
    {
        public void ManageRents()
        {
            while (true)
            {
                Console.WriteLine("\n==========  Rent Management ==========");
                Console.WriteLine("1. Lend a book");
                Console.WriteLine("2. Return a book");
                Console.WriteLine("3. List all rents");
                Console.WriteLine("4. Back to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": LendBook(); break;
                    case "2": ReturnBook(); break;
                    case "3": ListRents(); break;
                    case "4": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
        }
        public void ReturnBook()
        {
            //Check user
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Wrong input");
                return;
            }
            User user = library.users.First(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("A user with this id doesn't exist");
                return;
            }

            //Check book
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Wrong input");
                return;
            }

            Book book = library.books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("A book with this id doesn't exist");
                return;
            }

            models.Transaction transaction = library.transactions.FirstOrDefault(t => t.UserId == userId && t.BookId == bookId);
            if (transaction == null)
            {
                Console.WriteLine("This user hasn't borrowed this book");
                return;
            }

            book.AvailableCount++;
            library.transactions.Remove(transaction);
            Console.WriteLine("The user successfully returned the book");


            if (library.penalties.Any(t => t.UserId == user.Id))
            {
                Console.WriteLine("This user must pay penalty");
                new penalty_service().ManagePenalties();
                return;
            }

        }
        public void ListRents()
        {
            library.transactions.ForEach(t => Console.WriteLine(t));
        }
        public void LendBook()
        {
            //Check user
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Wrong input");
                return;
            }
            User user = library.users.First(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("A user with this id doesn't exist");
                return;
            }
            if(user.blocked)
            {
                Console.WriteLine("The user is blocked");
                return ;
            }
            if(library.penalties.Any(t => t.UserId == userId))
            {
                Console.WriteLine("This user must pay penaly");
                new penalty_service().ManagePenalties();
                return;
            }

            //Check book
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Wrong input");
                return;
            }

            Book book = library.books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("A book with this id doesn't exist");
                return;
            }

            //Check count
            if(book.AvailableCount <= 0)
            {
                Console.WriteLine("All books are rented");
                return;
            }
            if(library.transactions.Any(t => t.UserId == userId))
            {
                Console.WriteLine("The user already has rented this book");
            }

            library.transactions.Add(new models.Transaction
            {
                Id = library.transactions.Count + 1,
                UserId = user.Id,
                BookId = book.Id,
                LendDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7)
            });

            Console.WriteLine("Book successfully rented");
        }
    }
}
