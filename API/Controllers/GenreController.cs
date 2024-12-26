using Application.Commands.AuthorCommands.AddAuthor;
using Application.Commands.GenreCommands.AddGenre;
using Application.Commands.GenreCommands.DeleteGenre;
using Application.Dtos.GenreDtos;
using Application.Queries.GenreQueries.GetAllGenres;
using Application.Queries.GenreQueries.GetGenreById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IMediator mediator, ILogger<GenreController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<GenreController> _logger = logger;

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllGenres()
        {
            try
            {
                var operationResult = await _mediator.Send(new GetAllGenresQuery());
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult> GetGenre(int id)
        {
            try
            {
                var operationResult = await _mediator.Send(new GetGenreByIdQuery(id));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(AddGenreDto dto)
        {
            try
            {
                var operationResult = await _mediator.Send(new AddGenreCommand(dto));
                if (operationResult.IsSuccess)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<GetGenreDto>> UpdateGenre(int id, UpdateGenreDto updateGenreDto)
        //{
        //    var operationResult = await _mediator.Send()
        //    return Ok(genreToReturn);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            var operationResult = await _mediator.Send(new DeleteGenreCommand(id));
            return NoContent();
        }
    }
}
