using Movies.Application.Movies.Commands.CreateMovie;
using Movies.Application.Movies.Commands.DeleteMovie;
using Movies.Application.Movies.Commands.UpdateMovie;
using Movies.Application.Movies.Queries.GetMovies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Movies.WebUI.Controllers
{
    [Authorize]
    public class MoviesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<MoviesVm>> Get()
        {
            return await Mediator.Send(new GetMoviesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoviesVm>> Get(int id)
        {
             return await Mediator.Send(new GetMoviesByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateMovieCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateMovieCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMovieCommand { Id = id });

            return NoContent();
        }
    }
}
