using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalMovies.Data
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "Must Select Genre")]
        [StringLength(255)]
        public string Name { get; set; }
    }
}