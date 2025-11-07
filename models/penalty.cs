using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.models
{
    public class Penalty
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int Fine { get; set; } 
    }
}
