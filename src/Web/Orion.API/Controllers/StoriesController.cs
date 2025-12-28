using Microsoft.AspNetCore.Mvc;
using Orion.API.Controllers.SeedWork;
using Orion.Application.StoryAppLayer.UseCases.CreateStory;
using Orion.Application.StoryAppLayer.UseCases.DeleteStory;
using Orion.Application.StoryAppLayer.UseCases.GetStories;
using Orion.Application.StoryAppLayer.UseCases.GetStoryById;
using Orion.Application.StoryAppLayer.UseCases.UpdateStory;
using System.Threading.Tasks;

namespace Orion.API.Controllers
{
    [Route("api/[controller]")]
    public class StoriesController : OrionBaseController
    {
        public StoriesController() { }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok("Stories Service is healthy.");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] GetStoriesQuery query)
        {
            var stories = await Mediator.Send(query);
            return Ok(stories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var story = await Mediator.Send(new GetStoryByIdQuery { Id = id });
            if (story == null)
            {
                return APIErrors.RecordNotFound;
            }
            return Ok(story);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateStoryCommand command)
        {
            var storyId = Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = storyId }, null);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] UpdateStoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }
            var story = Mediator.Send(command);
            return Ok(story);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var story = Mediator.Send(new DeleteStoryCommand { Id = id });
            return Ok(story);
        }
    }
}