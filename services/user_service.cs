using Library.data;
using Library.models;
using Library.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.services
{
    public class user_service
    {
        public void ManageUsers()
        {
            while (true)
            {
                Console.WriteLine("\n=====  user management =====");
                Console.WriteLine("1. Register new user");
                Console.WriteLine("2. List all users");
                Console.WriteLine("3. Block user");
                Console.WriteLine("4. Unblock user");
                Console.WriteLine("5. Back to main menu");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RegisterUser(); break;
                    case "2": ListUsers(); break;
                    case "3": BlockUser(); break;
                    case "4": UnblockUser(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
        private void RegisterUser()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            if(library.users.Any(u => u.Email == email))
            {
                Console.WriteLine("This email is already registered");
                return;
            }

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            string hashedPassword = Hashing_helper.HashPassword(password);

            User newUser = new User
            {
                PasswordHash = hashedPassword,
                Name = name,
                Email = email,
                Id = library.users.Count() + 1
            };

            library.users.Add(newUser);
            Console.WriteLine("New user successfully added");
            Console.ReadLine();
        }

        private void ListUsers()
        {
            if (!library.users.Any())
                Console.WriteLine("There are no users");
            foreach(var user in library.users)
                Console.WriteLine(user);
            Console.ReadLine();
        }

        private void BlockUser()
        {
            Console.WriteLine("Id: ");
            if(!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Wrong input");
                return;
            }
            User user = library.users.First(u => u.Id == id);
            if (user == null)
            {
                Console.WriteLine("A user with this id doesn't exist");
                return;
            }
            if(user.blocked==true)
            {
                Console.WriteLine("The user was blocked");
                return;
            }
            user.blocked = true;
            Console.WriteLine("The user has been blocked successfully");
        }
        private void UnblockUser()
        {
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Wrong input");
                return;
            }
            User user = library.users.First(u => u.Id == id);
            if (user == null)
            {
                Console.WriteLine("A user with this id doesn't exist");
                return;
            }
            if (user.blocked == false)
            {
                Console.WriteLine("The user was unblocked");
                return;
            }
            user.blocked = false;
            Console.WriteLine("The user has been unblocked successfully");
        }
    }
}
