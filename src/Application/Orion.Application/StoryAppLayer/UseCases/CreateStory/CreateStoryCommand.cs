using MediatR;
using Orion.Application.StoryAppLayer.DTOs;

namespace Orion.Application.StoryAppLayer.UseCases.CreateStory
{
    public class CreateStoryCommand : IRequest<StoryDto>
    {
        public string Text { get; set; }
        public string[] Images { get; set; }
    }
}
