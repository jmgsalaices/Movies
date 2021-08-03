using Movies.Application.Comments.Commands.CreateComment;
using Movies.Application.Comments.Commands.DeleteComment;
using Movies.Application.Comments.Commands.UpdateComment;
//using Movies.Application.Comments.Queries.GetComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Movies.WebUI.Controllers
{
    [Authorize]
    public class CommentsController : ApiControllerBase
    {
       /* [HttpGet]
        public async Task<ActionResult<CommentVm>> Get()
        {
            return await Mediator.Send(new GetCommetsQuery());
        }*/

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCommentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCommentCommand command)
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
            await Mediator.Send(new DeleteCommentCommand { Id = id });

            return NoContent();
        }
    }
}
