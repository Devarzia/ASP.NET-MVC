using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Entities;
using BookstoreChain.Domain.Concrete;

namespace BookstoreChain.Domain.Abstract
{
    // Interface showing method definitions for book class
    public interface IBookRepository
    {
        // Retrieving all books from dataset
        IQueryable<Book> Books { get; }

        // Method to save book
        void SaveBook(Book book);

        // Method to delete book
        Book DeleteBook(int bookID);
    }
}
