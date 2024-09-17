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
            var authors = await _context.Authors.ToListAsync();//
            resp.Data = authors;
            resp._message = "Todos os autores foram coletados!";
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

    public async Task<ResponseModel<AuthorModel>> FindAuthorById(int idAuthor)
    {
        ResponseModel<AuthorModel> resp = new ResponseModel<AuthorModel>();
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == idAuthor); //entre no nosso banco, na tabela de autores,procure o primeiro com a informação id escrita.
            
            if(author == null)
            {
                resp._message = "Nenhum registro localizado.";
                return resp;
            }

            resp.Data = author;
            resp._message = "Autor localizado.";
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
