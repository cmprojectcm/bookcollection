using AutoMapper;
using BookCollection.Data;
using BookCollection.Data.Models;
using BookCollection.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookCollection.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookRatingController : ControllerBase

    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BookRatingController(AppDbContext db, IMapper mapper, ILogger<BookRatingController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        // POST api/<BookRatingController>
        [HttpPost]
        public async Task<IActionResult> AddBookRating([FromBody] BookRatingDto bookRatingDto)
        {
            _logger.LogInformation("Adding Book ratings from {name} at {DT}", nameof(BookRatingController), DateTime.UtcNow.ToLongTimeString());
            if (bookRatingDto.ratingValue.Count > 0) 
            {
                foreach(var rating in bookRatingDto.ratingValue)
                {
                    Ratings tmpRating = new Ratings() { BookId=bookRatingDto.BookId, ratingValue=rating.value };
                    await _db.Ratings.AddAsync(tmpRating);
                    await _db.SaveChangesAsync();
                }
                return Ok();
            }
            return NotFound();
               
        }
    }
}
