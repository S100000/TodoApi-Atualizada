﻿using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AuthorModel> Authors { get; set; } //essa é a "forma" para criar tabelas no banco que for conectado. Eu estou dizendo que quero
        public DbSet<BookModel> Books { get; set; }    //criar uma tabela chamada Authors, e suas colunas terão todas as propriedades do model Author.
    }
}
