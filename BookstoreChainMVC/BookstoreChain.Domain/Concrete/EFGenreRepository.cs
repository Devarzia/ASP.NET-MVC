using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Entities;
using BookstoreChain.Domain.Abstract;

namespace BookstoreChain.Domain.Concrete
{
    public class EFGenreRepository : IGenreRepository
    {
        // Creating a new instance of the Genre database
        private EFDbContext context = new EFDbContext();

        // Retriving all of the genres from the book table
        public IQueryable<Genre> Genres
        {
            // Setting the get attribute to retrieve all Genres from the database
            get
            {
                return context.Genres;
            }
        }

        // Saving a genre to the database
        public void SaveGenre(Genre genre)
        {
            // If statement to save genre to the database
            if (genre.GenreID == 0)
            {
                context.Genres.Add(genre);
            }

            else
            {
                // Finding an existing genre in the database
                Genre genreEntry = context.Genres.Find(genre.GenreID);

                // If the genreEntry is null, link genreEntry information to genre information
                if (genreEntry != null)
                {
                    genreEntry.Name = genre.Name;
                }
            }

            // Save changes to database
            context.SaveChanges();
        }

        // Deleting a genre from the database
        public Genre DeleteGenre(int genreID)
        {
            // Finding the genre requested by ID
            Genre genreEntry = context.Genres.Find(genreID);

            // Deleting the entry if found and save changest to the database
            if (genreEntry != null)
            {
                context.Genres.Remove(genreEntry);
                context.SaveChanges();
            }

            // returning the genre entry
            return genreEntry;
        }
    }
}