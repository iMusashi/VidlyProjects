using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        public int Count { get; set; }

        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }
    }
}