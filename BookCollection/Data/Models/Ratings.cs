using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models
{
    [Index(nameof(Id))]
    public class Ratings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int ratingValue { get; set; }

        [Required]
        [ForeignKey(name: "BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        
        
    }
}
