using System;
using AutoMapper;
using BibliotecaApi.Application.DTOs;
using BibliotecaApi.Domain.Entities;

namespace BibliotecaApi.Application.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, BookResponseDto>().ReverseMap();
        CreateMap<Book, BookCreateDto>().ReverseMap();
        CreateMap<Book, BookUpdateDto>().ReverseMap();
    }
}
