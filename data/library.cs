using Library.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.data
{
    internal class library
    {
        public static List<User> users = new List<User>();
        public static List<Book> books = new List<Book>();
        public static List<Author> authors = new List<Author>();
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<Penalty> penalties = new List<Penalty>();
    }
}
