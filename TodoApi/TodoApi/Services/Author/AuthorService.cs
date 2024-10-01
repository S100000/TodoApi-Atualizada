using Microsoft.EntityFrameworkCore;
using TodoApi.Dto;
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

    public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(CreateAuthorDto createAuthorDto)
    {
        ResponseModel<List<AuthorModel>> resp = new ResponseModel<List<AuthorModel>> ();

        try
        {
            var author = new AuthorModel()
            {
                Name = createAuthorDto.Name,
                LastName = createAuthorDto.LastName
            };
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            resp.Data = await _context.Authors.ToListAsync();
            resp._message = "Author successfully created";
            return resp;
        }
        catch (Exception ex)
        {
            resp._message = ex.Message;
            resp.Status = false;
            return resp;
        }
    }

    public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor)
    {
        ResponseModel<List<AuthorModel>> resp = new ResponseModel<List<AuthorModel>>();

        try
        {

            var author = await _context.Authors.FirstOrDefaultAsync(bankAuthor => bankAuthor.Id == idAuthor);

            if(author == null)
            {
                resp._message = "no authors found";
                return resp;
            }

            _context.Remove(author);
            resp.Data = await _context.Authors.ToListAsync();
            resp._message = "Author successfully  removed";
            return resp;
        }
        catch(Exception ex) 
        {
            resp._message = ex.Message;
            resp.Status = false;
            return resp;
        }
    }

    public async Task<ResponseModel<List<AuthorModel>>> EditAuthor(EditauthorDto editAuthorDto)
    {
        ResponseModel<List<AuthorModel>> resp = new ResponseModel<List<AuthorModel>>();
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync(bankAuthor => bankAuthor.Id == editAuthorDto.Id);


            if (author == null)
            {
                resp._message = "no authors found";
                return resp;
            }

            author.Name = editAuthorDto.Name;
            author.LastName = editAuthorDto.LastName;

            resp.Data = await _context.Authors.ToListAsync();
            resp._message = "Author successfully edited";

            return resp;
        }
        catch (Exception ex)
        {
            resp._message = ex.Message;
            resp.Status = false;
            return resp;
        }
    }

    public async Task<ResponseModel<AuthorModel>> FindAuthorByBook(int idBook)
    {
        ResponseModel<AuthorModel> resp = new ResponseModel<AuthorModel>();
        try
        {
            var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(BookBank => BookBank.Id == idBook);
            
            if(book == null)
            {
                resp._message = "nennhum autor encontrado.";
                return resp;
            }

            resp.Data = book.Author;
            return resp;
        }
        catch (Exception ex)
        {
            resp._message = ex.Message;
            resp.Status = false;
            return resp;
        }
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
