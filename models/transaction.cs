using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.models
{
    internal class Transaction
    {
        public int Id;
        public int UserId ;
        public int BookId;
        public DateTime LendDate;
        public DateTime ReturnDate;
    }
}
