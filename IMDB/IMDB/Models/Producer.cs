using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public sealed class Producer
    {
        public Producer()
        {
            Movies = new List<Movie>();
            TmdbId = 0;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(40, ErrorMessage ="Name cannot be longer than 40 characters.")]
        public string Name { get; set; }

        [StringLength(1, ErrorMessage = "Sex can be M or F.")]
        public string Sex { get; set; }

        [StringLength(20, ErrorMessage = "Max 20 Chars allowed.")]
        public string Dob { get; set; }

        [StringLength(5000, ErrorMessage = "Bio cannot be longer than 1500 characters.")]
        public string Bio { get; set; }
        public List<Movie> Movies { get; set; }

        public int? TmdbId { get; set; }

    }
}