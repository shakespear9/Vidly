﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Display(Name="Genre")]
        public Byte GenreId { get; set; }
        public Genre Genre { get; set; }   

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

       
        public DateTime AddedDate { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }


        

    }
}