using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TodoApi.Dto.Book;
using TodoApi.Models;

namespace TodoApi.Services.Book
{
    public class BookService : BookInterface
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<BookModel>>> BookList()
        {
            ResponseModel<List<BookModel>> resp = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).ToListAsync();
                resp._message = "All books were found";
                resp.Data = book;

                return resp;
            }
            catch (Exception ex)
            {
                resp._message = ex.Message;
                resp.Status = false;
                return resp;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> CreateBook(CreateBookDto createBookDto)
        {
            ResponseModel<List<BookModel>> resp = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == createBookDto.Author.Id);

                if (author == null)
                {
                    resp._message = "Auhtor not found";
                    return resp;
                }

                var book = new BookModel()
                {
                    Name = createBookDto.Name,
                    Author = author
                };
                _context.Add(book);
                await _context.SaveChangesAsync();

                resp.Data = await _context.Books.Include(a => a.Author).ToListAsync();
                resp._message = "Book successfuly created";

                return resp;
            }
            catch (Exception ex)
            {
                resp._message = ex.Message;
                resp.Status = false;
                return resp;
            }
        }

        public Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<BookModel>>> EditBook(EditBookDto editBookDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<BookModel>>> GetBookByAuthor(int idAuthor)
        {
            ResponseModel<List<BookModel>> resp = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).Where(bankAuthor => bankAuthor.Author.Id == idAuthor).ToListAsync();
                if (book == null)
                {
                    resp._message = "Book Not Found";
                    return resp;
                }

                resp.Data = book;
                resp._message = "Book successfully found";

                return resp;
            }
            catch (Exception ex)
            {
                resp._message = ex.Message;
                resp.Status = false;
                return resp;
            }
        }

        public async Task<ResponseModel<BookModel>> GetBookById(int idBook)
        {
            ResponseModel<BookModel> resp = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(bankBook => bankBook.Id == idBook);
                if(book == null)
                {
                    resp._message = "Book Not Found";
                    return resp;
                }

                resp.Data = book;
                resp._message = "Book successfully found";

                return resp;
            }
            catch (Exception ex)
            {
                resp._message = ex.Message;
                resp.Status = false;
                return resp;
            }
        }
    }
}
