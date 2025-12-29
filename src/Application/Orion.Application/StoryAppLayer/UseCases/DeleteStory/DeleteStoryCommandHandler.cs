using MediatR;
using Orion.Application.StoryAppLayer.DTOs;
using Orion.Application.StoryAppLayer.Gateway;

namespace Orion.Application.StoryAppLayer.UseCases.DeleteStory
{
    public class DeleteStoryCommandHandler : IRequestHandler<DeleteStoryCommand, StoryDto>
    {
        private readonly IStoryRepository _storyRepository;

        public DeleteStoryCommandHandler(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var deletedStory = await _storyRepository.RemoveAsync(request.Id);
            if (deletedStory == null)
            {
                return null;
            }

            var storyDto = new StoryDto
            {
                Id = deletedStory.Id,
                Text = deletedStory.Text,
                Images = deletedStory.Images
            };
            return storyDto;
        }
    }
}
