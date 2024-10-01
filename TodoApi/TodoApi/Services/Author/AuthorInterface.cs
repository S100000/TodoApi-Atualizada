using TodoApi.Models;
using TodoApi.Dto.Author;

namespace TodoApi.Services.Author
{
    public interface AuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> AuthorsList();
        Task<ResponseModel<AuthorModel>> FindAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> FindAuthorByBook(int idBook);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(CreateAuthorDto createAuthorDto);
        Task<ResponseModel<List<AuthorModel>>> EditAuthor(EditauthorDto editAuthorDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor);

    }
}
