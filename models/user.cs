using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.models
{
    public class User
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Email {  get; set; }
        public string PasswordHash {  get; set; }
        public string Number {  get; set; }
        public bool blocked {  get; set; }
    }
}
