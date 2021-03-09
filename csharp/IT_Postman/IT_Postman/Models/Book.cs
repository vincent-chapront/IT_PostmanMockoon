using System;

namespace IT_Postman.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
    }
}
