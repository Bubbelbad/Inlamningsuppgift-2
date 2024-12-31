using Application.Commands.ReviewCommands.AddReview;
using Application.Commands.ReviewCommands.DeleteReview;
using Application.Commands.ReviewCommands.UpdateReview;
using Application.Dtos.ReviewDtos;
using Application.Queries.ReviewQueries.GetAllReviews;
using Application.Queries.ReviewQueries.GetReviewById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var operationResult = await _mediator.Send(new GetAllReviewsQuery());
                if (operationResult is not null)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            try
            {
                var operationResult = await _mediator.Send(new GetReviewByIdQuery(id));
                if (operationResult is not null)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddReview(AddReviewDto dto)
        {
            try
            {
                var operationResult = await _mediator.Send(new AddReviewCommand(dto));
                if (operationResult is not null)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateReview(UpdateReviewDto dto)
        {
            try
            {
                var operationResult = await _mediator.Send(new UpdateReviewCommand(dto));
                if (operationResult is not null)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var operationResult = await _mediator.Send(new DeleteReviewCommand(id));
                if (operationResult is not null)
                {
                    return Ok(operationResult.Data);
                }
                return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

        }
    }
}
