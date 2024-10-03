using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dto.Book;
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

        [HttpGet("GetBookByAuthor")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBookByAuthor(int idAuthor)
        {
            var book = await _bookInterface.GetBookByAuthor(idAuthor);
            return Ok(book);
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(CreateBookDto createBookDto)
        {
            var book = await _bookInterface.CreateBook(createBookDto);
            return Ok(book);
        }
    } 
}
