using Quotopia.API.Models;

namespace Quotopia.API.Services
{
    public interface IQuoteService
    {
        Task<Quote> GetRandomQuote();
        Task<List<Quote>> GetQuotes();
        Task<List<Quote>> GetQuotesByTag(string tag);
        Task<Quote> GetQuoteById(int id);
        Task AddAllQuotes(List<Quote> quotes);
    }
}