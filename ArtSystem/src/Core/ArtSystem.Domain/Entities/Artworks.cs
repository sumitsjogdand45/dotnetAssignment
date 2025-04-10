
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtSystem.Domain.Entities
{
    public class Artworks
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ArtworkId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string ImageURL { get; set; }
    }
}
