using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Concrete;
using BookstoreChain.Domain.Entities;

namespace BookstoreChain.Domain.Abstract
{
    // Interface showing method definitions used for the Author Class
    public interface IAuthorRepository
    {
        // Retrieving all the Authors from the database
        IQueryable<Author> Authors { get; }

        // Saving a Author to the database
        void SaveAuthor(Author author);

        // Deleting the Author from the database
        Author DeleteAuthor(int authorID);
    }
}
