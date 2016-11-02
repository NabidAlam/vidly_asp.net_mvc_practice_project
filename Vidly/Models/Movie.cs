using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please specify the movie title")]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please specify how long the movie is in hours")]
        public double Duration { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage ="Please select a genre")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required(ErrorMessage ="Please specify stock amount")]
        [Display(Name = "Number in Stock")]
        [Range(0, 20, ErrorMessage ="Stock amount must be between 0 and 20, inclusive")]
        public int NumInStock { get; set; }

    }
}