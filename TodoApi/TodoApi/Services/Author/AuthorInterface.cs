using TodoApi.Models;

namespace TodoApi.Services.Author
{
    public interface AuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> AuthorsList();
        Task<ResponseModel<AuthorModel>> FindAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> FindAuthorByBook(int idBook);

    }
}
