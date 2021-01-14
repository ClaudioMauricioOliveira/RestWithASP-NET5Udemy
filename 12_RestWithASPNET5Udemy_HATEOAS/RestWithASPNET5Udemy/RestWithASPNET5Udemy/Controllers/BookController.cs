using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5Udemy.Business;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Hipermedia.Filters;

namespace RestWithASPNET5Udemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _bookBusiness.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
