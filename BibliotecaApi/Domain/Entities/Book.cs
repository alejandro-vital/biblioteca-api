using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Domain.Entities;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;
    public string? ISBN { get; set; }
    public DateTime? PublishedDate { get; set; }
    public string? Summary { get; set; }

}
