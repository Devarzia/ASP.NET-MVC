using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookstoreChain.Domain.Entities
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int BookID { get; set; }

        [Required(ErrorMessage = "Please Enter Book Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Please Enter Author Name of Book")]
        public string AuthorName { get; set; }
    }
}
