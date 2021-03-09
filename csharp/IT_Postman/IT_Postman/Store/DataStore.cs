using IT_Postman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Postman.Store
{
    public class DataStore
    {
        public List<Book> Books { get; } = new List<Book>();
    }
}
