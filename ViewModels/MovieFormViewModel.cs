using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {


        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }


        [Display(Name = "Number in Stock")]
        //[MoreThanOneNumberInStock]    
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }



        public IEnumerable<Genre> Genres { get; set; }


        public MovieFormViewModel()
        {
            Id = 0;
            NumberInStock = 0;
            ReleaseDate = DateTime.MinValue;

        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            GenreId = movie.GenreId;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;

        }

        public string Title
        {
            get
            {
                //if (Movie != null && Movie.Id != 0)
                //if (Id != 0 )
                //    return "Edit Movie";
                //return "New Movie";

                return Id != 0 ? "Edit Movie" : "New Movie";

            }
        }
    }
}