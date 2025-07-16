using System;
using BibliotecaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
