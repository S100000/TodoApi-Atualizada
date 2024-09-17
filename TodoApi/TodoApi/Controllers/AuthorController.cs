using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
