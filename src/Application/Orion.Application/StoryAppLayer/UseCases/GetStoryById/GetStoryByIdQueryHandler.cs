using MediatR;
using Orion.Application.StoryAppLayer.DTOs;
using Orion.Application.StoryAppLayer.Gateway;

namespace Orion.Application.StoryAppLayer.UseCases.GetStoryById
{
    public class GetStoryByIdQueryHandler : IRequestHandler<GetStoryByIdQuery, StoryDto>
    {
        private readonly IStoryRepository _storyRepository;

        public GetStoryByIdQueryHandler(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(GetStoryByIdQuery request, CancellationToken cancellationToken)
        {
            var story = await _storyRepository.GetByIdAsync(request.Id);
            if (story == null)
            {
                return null;
            }

            var storyDto = new StoryDto
            {
                Id = story.Id,
                Text = story.Text,
                Images = story.Images
            };
            return storyDto;
        }
    }
}
