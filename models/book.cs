using Library.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string ISSN { get; set; }
        public int AvailableCount { get; set; }
        public Genre Genre { get; set; }
        public int Year {  get; set; }
        public string Text { get; set; }
    }
}
