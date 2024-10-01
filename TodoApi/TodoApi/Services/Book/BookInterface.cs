using TodoApi.Dto.Book;
using TodoApi.Models;

namespace TodoApi.Services.Book
{
    public interface BookInterface
    {
        Task<ResponseModel<List<BookModel>>> BookList();
        Task<ResponseModel<BookModel>> GetBookById(int idBook);
        Task<ResponseModel<List<BookModel>>> GetBookByAuthor(int idAuthor);
        Task<ResponseModel<List<BookModel>>> CreateBook(CreateBookDto createBookDto);
        Task<ResponseModel<List<BookModel>>> EditBook(EditBookDto editBookDto);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook);
    }
}
