using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookstoreChain.Domain.Entities;

namespace BookstoreChainMVC.Models
{
    public class BookListModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}