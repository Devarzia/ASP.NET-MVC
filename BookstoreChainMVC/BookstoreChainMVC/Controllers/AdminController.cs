using BookstoreChain.Domain.Abstract;
using BookstoreChain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookstoreChainMVC.Controllers
{
    public class AdminController : Controller
    {
        #region Repositories
        // creating a new instance of all the respositories
        private IAuthorRepository authorRep;
        private IBookRepository bookRep;
        private IGenreRepository genreRep;
        private IStoreRepository storeRep;

        // Creating an instance of the AdminController
        public AdminController(IAuthorRepository authorRepository, IBookRepository bookRepository, IGenreRepository genreRepository, IStoreRepository storeRepository)
        {
            authorRep = authorRepository;
            bookRep = bookRepository;
            genreRep = genreRepository;
            storeRep = storeRepository;
        }
        #endregion

        #region Author
        // GET: Action Method that returns the list of Authors
        public ViewResult Author()
        {
            return View(authorRep.Authors);
        }

        // GET: Action method that return a view for creating a book
        public ActionResult CreateAuthor()
        {
            return View("EditAuthor", new Author());
        }

        // GET: Action Method that returns an author for editing
        public ViewResult EditAuthor(int authorID)
        {
            // Retriving an author by authorID
            Author author = authorRep.Authors.FirstOrDefault(a => a.AuthorID == authorID);

            // Return the view of the selected Author
            return View(author);
        }

        // POST: Action Method that saves the author after editing
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuthor(Author author)
        {
            // Calling the authorRep SaveAuthor Method and pass in the author parameter
            authorRep.SaveAuthor(author);

            // Sending a TempData message stating that the author has been saved
            TempData["message"] = string.Format("{0} has been saved", author.Name);

            // Redirect page to list of authors
            return RedirectToAction("Author");
        }

        // GET: Action Method that Deletes a book after being selected
        [HttpPost]
        public ActionResult DeleteAuthor(int authorID)
        {
            // Calling the IAuthorRepository Delete method and passing in the authorID parameter
            Author author = authorRep.DeleteAuthor(authorID);

            // Sending a message to show that the author has been deleted, if found
            if(author != null)
            {
                TempData["message"] = string.Format("{0} has been deleted!", author.Name);
            }

            // Redirecting to list of authors
            return RedirectToAction("Author");
        }
        #endregion

        #region Book
        // GET: Action Method that return a view of Books
        public ActionResult Book()
        {
            return View(bookRep.Books);
        }

        // GET: Action Method that return a view for creating a book
        public ActionResult CreateBook()
        {
            return View("EditBook", new Book());
        }

        // GET: Action Method that returns a book for editing
        public ViewResult EditBook(int bookId)
        {
            // Finding the book in the database by bookID
            Book book = bookRep.Books.FirstOrDefault(b => b.BookID == bookId);
             
            // Return the view of the book
            return View(book);
        }

        // POST: Action Method that saves a book after editing
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(Book book)
        {
            // Call the IBookRepository SaveBook method and pass in the book parameter
            bookRep.SaveBook(book);

            // Setting the Tempdata to display a message saying that the book has been saved
            TempData["message"] = string.Format("{0} has been saved", book.Title);

            // Redirecting to the list of books
            return RedirectToAction("Book");

        }

        // POST: Action method that deletes a book after being selected
        [HttpPost]
        public ActionResult DeleteBook(int bookID)
        {
            // Calling the IBookRepository DeleteBook method and pass in the bookID parameter
            Book book = bookRep.DeleteBook(bookID);

            // If book is found, a message is sent to the user stating that the book has been deleted
            if (book != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", book.Title);
            }

            // redirect to list of books
            return RedirectToAction("Book");

        }
        #endregion

        #region Genre
        // GET: ViewResult Method that return the list of Genres
        public ViewResult Genre()
        {
            return View(genreRep.Genres);
        }

        // GET: Action Method that returns a view for creating a genre
        public ActionResult CreateGenre()
        {
            // creating a new genre view using the EditGenre view
            return View("EditGenre", new Genre());
        }

        // GET: ViewResult Method that returns a selected genre for editing
        public ViewResult EditGenre(int genreID)
        {
            // Retriving the genre by genreID in the genre repository
            Genre genre = genreRep.Genres.FirstOrDefault(g => g.GenreID == genreID);

            // Returning the view of the selected genre
            return View(genre);
        }

        // POST: Action Method that saves an genre after editing 
        [HttpPost]
        public ActionResult EditGenre(Genre genre)
        {
            // Calling the Genre repository SaveGenre method and passing in the genre parameter
            genreRep.SaveGenre(genre);

            // Sending a message saying that the genre has been saved
            TempData["message"] = string.Format("{0} has been saved!", genre.Name);

            // Returning the view to a list of genres
            return RedirectToAction("Genre");
        }

        // POST: Action Method that deletes a genre
        [HttpPost]
        public ActionResult DeleteGenre(int genreID)
        {
            // Calling the IGenreRepository DeleteGenre Method and passing in the genreID parameter
            Genre genre = genreRep.DeleteGenre(genreID);

            // Sending a message saying that the genre has been deleted
            TempData["message"] = string.Format("{0} has been deleted!", genre.Name);

            // Returns the view to the list of genres
            return RedirectToAction("Genre");
        }
        #endregion

        #region Store
        // GET: ViewResult Method that returns the list of Stores
        public ViewResult Store()
        {
            return View(storeRep.Stores);
        }

        // GET: Action Method that return a view to create a new store
        public ActionResult CreateStore()
        {
            // returning the editgenre view to create a new store
            return View("EditStore", new Store());
        }

        // GET: ViewResult method that returns a store for editing
        public ViewResult EditStore(int storeID)
        {
            // Retrieving the store for editing by storeID
            Store store = storeRep.Stores.FirstOrDefault(s => s.StoreID == storeID);

            // return the view of the selected store
            return View(store);
        }

        // POST: Action method that saves the store
        [HttpPost]
        public ActionResult EditStore(Store store)
        {
            // Calling the IStoreRepository SaveStore method and pass in the store paremeter
            storeRep.SaveStore(store);

            // Sending a message saying that the store has been saved
            TempData["message"] = string.Format("{0} has been saved!", store.Name);

            // Returning the view to the list of stores
            return RedirectToAction("Store");
        }

        // POST: Action Method the deletes a store
        [HttpPost]
        public ActionResult DeleteStore(int storeID)
        {
            // Calling the IStoreRepository DeleteStore method and pass in the storeID parameter
            Store store = storeRep.DeleteStore(storeID);

            // Sending a messages saying that the store has been deleted
            TempData["message"] = string.Format("{0} has been deleted!", store.Name);

            // Return the view to the list of stores
            return RedirectToAction("Store");
        }
        #endregion
    }
}