using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Quotopia.API.Data;
using Quotopia.API.Models;

namespace Quotopia.API.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly string _memoryCacheKey = "quotes";
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public QuoteService(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public async Task<Quote> GetRandomQuote()
        {
            var quotes = await GetQuotes();

            var randomVal = new Random();

            if (quotes != null && quotes.Any())
            {
                return quotes[randomVal.Next(0, quotes.Count - 1)];
            }

            return new Quote();
        }

        public async Task<List<Quote>> GetQuotes()
        {
            var quotes = new List<Quote>();

            if (!_memoryCache.TryGetValue(_memoryCacheKey, out quotes))
            {
                quotes = await _dbContext.Quotes.ToListAsync();

                _memoryCache.Set(_memoryCacheKey, quotes);
            }

            return quotes ?? new List<Quote>();
        }

        public async Task<List<Quote>> GetQuotesByTag(string tag)
        {
            var quotes = await GetQuotes();

            return quotes.Where(x=>x.Tag.Equals(tag, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public async Task<Quote> GetQuoteById(int id)
        {
            var quotes = await GetQuotes();

            return quotes.Where(x => x.Id == id).FirstOrDefault() ?? new Quote();
        }

        public async Task AddAllQuotes(List<Quote> quotes)
        {
           _dbContext.Quotes.AddRange(quotes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
