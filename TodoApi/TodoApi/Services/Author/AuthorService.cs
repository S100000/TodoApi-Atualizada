using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Services.Author;

public class AuthorService : AuthorInterface
{
    private readonly AppDbContext _context;
    public AuthorService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<List<AuthorModel>>> AuthorsList()
    {
        ResponseModel<List<AuthorModel>> resp = new ResponseModel<List<AuthorModel>>();
        try
        {
            var authors = await _context.Authors.ToListAsync();
            resp.Data = authors;
            resp._message = "Todos os autores foram coletados!";
            resp.Status = true;
            return resp; ;
        }
        catch (Exception ex)
        {
            resp._message = ex.Message;
            resp.Status = false;
            return resp;
        }
    }

    public Task<ResponseModel<AuthorModel>> FindAuthorByBook(int idBook)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<AuthorModel>> FindAuthorById(int idAuthor)
    {
        throw new NotImplementedException();
    }
}
