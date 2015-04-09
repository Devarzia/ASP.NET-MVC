using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookstoreChain.Domain.Entities
{
    public class Genre
    {
        [HiddenInput(DisplayValue = false)]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Please Enter Genre Name")]
        public string Name { get; set; }
    }
}
