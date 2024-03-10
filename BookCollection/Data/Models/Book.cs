using BookCollection.Dto;
using BookCollection.Dto.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace BookCollection.Data.Models
{
    [Index(nameof(Id))]
    [Index(nameof(Title))]
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public BookType Type { get; set; }

        public double? averageRating { get;  set; }

        public int? totalRating { get;  set; }

        public List<Ratings> Ratings { get; set; } = new List<Ratings>();

        public void GetAverage()
        {
            if (this.Ratings != null)
            {
                //AllRatings.Add(this.rating.Value);
                this.averageRating = this.Ratings.Average(x => x.ratingValue);
            }
        }

        public void RatingsTotal()
        {
            this.totalRating = this.Ratings.Count();
        }
    }
}
