using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services.Book;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookInterface _bookInterface;
        public BookController(BookInterface bookInterFace)
        {
            _bookInterface = bookInterFace;
        }

        [HttpGet("BookList")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> BookList()
        {
            var book = await _bookInterface.BookList();
            return Ok(book);
        }

        [HttpGet("GetBookById")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int idBook)
        {
            var book = await _bookInterface.GetBookById(idBook);
            return Ok(book);
        }

    }
}
