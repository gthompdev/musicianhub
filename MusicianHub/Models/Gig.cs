using System;
using System.ComponentModel.DataAnnotations;

namespace MusicianHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required] //resharper auto resolves this
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required] //bc a venue is required
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required] public byte GenreId { get; set; }
    }
}