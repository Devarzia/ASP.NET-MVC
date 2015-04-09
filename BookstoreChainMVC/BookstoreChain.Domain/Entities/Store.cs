using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookstoreChain.Domain.Entities
{
    public class Store
    {
        [HiddenInput(DisplayValue = false)]
        public int StoreID { get; set; }

        [Required(ErrorMessage = "Please Enter Store Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please Enter Store Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Store City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Store State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Store Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
