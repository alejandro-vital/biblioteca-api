using AutoMapper;
using BibliotecaApi.Application.DTOs;
using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books == null || !books.Any())
                return NotFound("No se encontraron libros");


            var productsDto = _mapper.Map<IEnumerable<BookResponseDto>>(books);

            return Ok(productsDto);
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult<BookResponseDto>> GetBookByIdAsync(int id)
        {
            if (id <= 0) return BadRequest($"El ID {id} es invalido");

            var books = await _bookRepository.GetByIdAsync(id);
            if (books == null)
                return NotFound($"No se encontro el libro con el id {id}");

            var bookDto = _mapper.Map<BookResponseDto>(books);

            return Ok(bookDto);

        }

        [HttpPost]
        public async Task<ActionResult<BookResponseDto>> CreateBookAsync([FromBody] BookCreateDto bookCreateDto)
        {
            if (bookCreateDto == null) return BadRequest("Los datos son invalidos");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var book = _mapper.Map<Book>(bookCreateDto);

            var createdBook = await _bookRepository.CreateAsync(book);
            if (createdBook == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el libro");

            var bookDto = _mapper.Map<BookResponseDto>(createdBook);

            return CreatedAtAction(
                "GetBookById",
                new { id = bookDto.Id },
                bookDto
            );
        }

        [HttpPut]
        public async Task<ActionResult<BookResponseDto>> UpdateBookAsync(int id, [FromBody] BookUpdateDto bookUpdateDto)
        {
            if (id <= 0) return BadRequest($"El ID {id} es invalido");

            if (bookUpdateDto == null) return BadRequest("Los datos son invalidos");
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var existsBook = await _bookRepository.GetByIdAsync(id);
            if (existsBook == null)
                return NotFound($"No se encontro el libro con el id {id}");

            _mapper.Map(bookUpdateDto, existsBook);

            var updatedBook = await _bookRepository.UpdateAsync(existsBook);
            if (updatedBook == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el libro");

            var bookDto = _mapper.Map<BookResponseDto>(updatedBook);

            return Ok(bookDto);


        }


        [HttpDelete]
        public async Task<ActionResult> DeleteBookAsync(int id)
        {
            if (id <= 0) return BadRequest($"El ID {id} es invalido");
            var existsBook = await _bookRepository.GetByIdAsync(id);
            if (existsBook == null)
                return NotFound($"No se encontro el libro con el id {id}");
            var deleted = await _bookRepository.DeleteAsync(existsBook);
            if (!deleted)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el libro");

            return Ok($"Libro con el ID: {id}, eliminado correctamente");

        }




    }
}
