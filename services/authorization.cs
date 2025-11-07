using Library.data;
using Library.models;
using Library.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.services
{
    public class authorization
    {
        public bool login()
        {
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            User user = library.users.FirstOrDefault(c => c.Email == email);
            if (user == null || !Hashing_helper.VerifyPassword(password, user.PasswordHash)){
                Console.WriteLine("Invalid credentials");
                return false;
            }

            Console.WriteLine("Login successfull");
            return true;
        }
    }
}
