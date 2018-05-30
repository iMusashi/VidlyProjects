using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Please enter a number between 1 and 20.")]
        public int Count { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}