using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Application.DTOs;

public class BookResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string? ISBN { get; set; }
    public DateTime? PublishedDate { get; set; }
    public string? Summary { get; set; }
}
