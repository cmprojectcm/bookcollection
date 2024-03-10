using System.ComponentModel.DataAnnotations;

namespace BookCollection.Dto
{
    public class BookRatingDto:RatingsDto
    {
        public int BookId { get; set; }
        public List<RatingValue> ratingValue { get; set; }

        
    }

    public class RatingValue
    {
        [Required]
        [Range(1, 5, ErrorMessage ="Rating Value should be between 1 and 5")]
        public int value { get; set; }
    }

}

