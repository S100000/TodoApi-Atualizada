using TodoApi.Dto.Links;
using TodoApi.Models;

namespace TodoApi.Dto.Book
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public AuthorLinkDto Author { get; set; }
    }
}
