using Library.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class App
    {
        private static authorization authService = new authorization();
        public static void Run()
        {
            Console.WriteLine("=========  Admin Panel ==========");
            if (!authService.login()) return;

            ShowMenu();
        }
        private static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Manage Books");
                Console.WriteLine("2. Manage Users");
                Console.WriteLine("3. Rentals");
                Console.WriteLine("4. Reports");
                Console.WriteLine("5. Logout");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": new book_service().ManageBooks(); break;
                    case "2": new user_service().ManageUsers(); break;
                    case "3": new rental_service().ManageRents(); break;
                    case "4": new penalty_service().ManagePenalties(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }
    }
}
