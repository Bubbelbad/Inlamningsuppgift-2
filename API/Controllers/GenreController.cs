using Application.Queries.GenreQueries.GetAllGenres;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetGenre(int id)
        {
            //var operationResult = await _mediator.Send()
            return BadRequest();
        }

        //[HttpPost]
        //public async Task<ActionResult<GetGenreDto>> CreateGenre(CreateGenreDto createGenreDto)
        //{
        //    var operationResult = await _mediator.Send()
        //    return Ok(genreToReturn);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<GetGenreDto>> UpdateGenre(int id, UpdateGenreDto updateGenreDto)
        //{
        //    var operationResult = await _mediator.Send()
        //    return Ok(genreToReturn);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteGenre(int id)
        //{
        //    var operationResult = await _mediator.Send()
        //    return NoContent();
        //}
    }
}
