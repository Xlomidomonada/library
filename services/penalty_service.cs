using Library.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.services
{
    internal class penalty_service
    {
        public void ManagePenalties()
        {
            while (true)
            {
                Console.WriteLine("\n========== Penalty Management ==========");
                Console.WriteLine("1. Pay the fines");
                Console.WriteLine("2. List all fines");
                Console.WriteLine("3. Back to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": PayFine(); break;
                    case "2": ListPenalties(); break;
                    case "3": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
        }
        public void ListPenalties()
        {
            library.penalties.ForEach(p => Console.WriteLine(p));
        }
        public void PayFine()
        {

        }
    }
}
