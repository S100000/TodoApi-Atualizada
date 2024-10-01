using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dto.Author;
using TodoApi.Models;
using TodoApi.Services.Author;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorInterface _authorInterface;
        public AuthorController(AuthorInterface autorInterFace)
        {
               _authorInterface = autorInterFace;
        }

        [HttpGet("AuthorList")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> AuthorsList()
        {
            var authors = await _authorInterface.AuthorsList();
            return Ok(authors);
        }

        [HttpGet("FindAuthorById/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> FindAuthorById(int idAuthor)
        {
            var author = await _authorInterface.FindAuthorById(idAuthor);
            return Ok(author);
        }

        [HttpGet("FindAuthorByBook/{idBook}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> FindAuthorByBook(int idBook)
        {
            var book = await _authorInterface.FindAuthorByBook(idBook);
            return Ok(book);
        }

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = await _authorInterface.CreateAuthor(createAuthorDto);
            return Ok(createAuthorDto);
        }

        [HttpPut("EditAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> EditAuthor(EditauthorDto editAuthorDto)
        {
            var author = await _authorInterface.EditAuthor(editAuthorDto);
            return Ok(author);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> DeleteAuthor(int idAuthor)
        {
            var author = await _authorInterface.DeleteAuthor(idAuthor);
            return Ok(author);
        }
    }
}

