using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Duration { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Stock amount must be between 0 and 20, inclusive")]
        public int NumInStock { get; set; }
    }
}