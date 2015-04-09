using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Entities;
using BookstoreChain.Domain.Concrete;

namespace BookstoreChain.Domain.Abstract
{
    // Interface showing method definitions for the Genre Class
    public interface IGenreRepository
    {
        // Retrieving all Genres from the database
        IQueryable<Genre> Genres { get; }

        // Save a Genre to the database
        void SaveGenre(Genre genre);

        // Delete a Genre from the database
        Genre DeleteGenre(int genreID);
    }
}
