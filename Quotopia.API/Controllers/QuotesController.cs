using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotopia.API.Models;
using Quotopia.API.Services;

namespace Quotopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<List<Quote>> Get()
        {
            return await _quoteService.GetQuotes();
        }

        [HttpPost(Name = "AddAllQuotes")]
        public async Task AddAllQuotes([FromBody] List<Quote> quotes)
        {
           await _quoteService.AddAllQuotes(quotes);
        }
    }
}
