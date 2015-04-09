using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Abstract;
using BookstoreChain.Domain.Entities;

namespace BookstoreChain.Domain.Concrete
{
    public class EFAuthorRepository : IAuthorRepository
    {
        // Creating a new instance of the Author Table 
        private EFDbContext context = new EFDbContext();

        // Retrieving all of the authors from the new instance 
        public IQueryable<Author> Authors
        {
            // Setting the get attribute to return 
            // authors from the new instance of the database
            get
            {
                return context.Authors;
            }
        }

        // Saving the authors to the database
        public void SaveAuthor(Author author)
        {
            // If statement to save book to the database
            if (author.AuthorID == 0)
            {
                context.Authors.Add(author);
            }

            else
            {
                // Finding an existing book by ID
                Author authorEntry = context.Authors.Find(author.AuthorID);

                //If the authorEntry is null, link the authorEntry information to author information
                if(authorEntry != null)
                {
                    authorEntry.Name = author.Name;
                    authorEntry.Address = author.Address;
                    authorEntry.City = author.City;
                    authorEntry.State = author.State;
                    authorEntry.PhoneNumber = author.PhoneNumber;
                }
            }

            // Saving changes to the database
            context.SaveChanges();
        }

        // Deleting an author to the database
        public Author DeleteAuthor(int authorID)
        {
            // Finding the authorEntry in the database by ID
            Author authorEntry = context.Authors.Find(authorID);

            // Deleting the authorEntry if the authorID is found and save changes to the database
            if (authorEntry != null)
            {
                context.Authors.Remove(authorEntry);
                context.SaveChanges();
            }

            // Return the authorEntry
            return authorEntry;
        }
    }
}