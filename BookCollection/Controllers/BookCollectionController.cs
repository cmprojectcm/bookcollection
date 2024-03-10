using BookCollection.Models;
using Microsoft.AspNetCore.Mvc;
using BookCollection.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookCollection.Data.Models;
using BookCollection.Dto.Enums;
using BookCollection.Dto;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookCollection.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookCollectionController : ControllerBase
    {

        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BookCollectionController(AppDbContext db, IMapper mapper, ILogger<BookCollectionController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookCollection()
        {
            _logger.LogInformation("Getting All Books from {name} at {DT}", nameof(BookCollection), DateTime.UtcNow.ToLongTimeString());
            if(_db.Books == null) 
            {
                return NotFound();
            }
            var books = await _db.Books.Include(b=>b.Ratings).ToListAsync();
            books = AverageAndRatingsTotal.GetAverageAndRatingsTotal(books);
            if (books.Count >0) { 
                return Ok(_mapper.Map<List<BookDto>>(books)); 
            }
            return BadRequest();
            
        }


        // POST api/<BookCollectionController>
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto book)
        {
            _logger.LogInformation("Adding a Books from {name} at {DT}", nameof(BookCollection), DateTime.UtcNow.ToLongTimeString());
            var result = await _db.Books.AddAsync(_mapper.Map<Book>(book));
            await _db.SaveChangesAsync();
            return Ok("Book Added Successfully");
        }

        [HttpPost]
        public async Task<IActionResult> SearchBookByTitle([FromBody] string stringToSearch)
        {
            _logger.LogInformation("Searching a Books from {name} at {DT}", nameof(BookCollection), DateTime.UtcNow.ToLongTimeString());
            var result = await _db.Books.Where(b=> b.Title.Contains(stringToSearch)).Include(b=>b.Ratings).ToListAsync();
            result = AverageAndRatingsTotal.GetAverageAndRatingsTotal(result);
            return Ok(_mapper.Map<List<BookDto>>(result));
        }

    }

    public static class AverageAndRatingsTotal { 
        public static List<Book> GetAverageAndRatingsTotal(List<Book> booksList) {

            foreach (var book in booksList)
            {
                book.GetAverage();
                book.RatingsTotal();
            }

            return booksList;
        }
    }
}
