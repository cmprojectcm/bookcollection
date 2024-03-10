namespace BookCollection.ApiResponses
{
    public class BaseExceptionResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
