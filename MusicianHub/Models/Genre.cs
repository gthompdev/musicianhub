using System.ComponentModel.DataAnnotations;

namespace MusicianHub.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required] // resharper determines that "Required" is part of System.ComponentModel.DataAnnotations and adds the using statement
        [StringLength(255)]
        public string Name { get; set; }
    }
}