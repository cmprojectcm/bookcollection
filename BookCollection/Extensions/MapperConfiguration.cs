using AutoMapper;
using BookCollection.Data.Models;
using BookCollection.Dto;
using BookCollection.Models;

namespace BookCollection.Extensions
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Book, BookDto>().PreserveReferences();
            CreateMap<BookDto, Book>().PreserveReferences();
            CreateMap<BookRatingDto, Ratings>().PreserveReferences();
            CreateMap<Ratings, BookRatingDto>().PreserveReferences();
            CreateMap<RatingsDto, Ratings>().PreserveReferences();
            CreateMap<Ratings, RatingsDto>().PreserveReferences();
        }
    }
}
