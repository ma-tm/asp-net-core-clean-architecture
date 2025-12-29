using MediatR;
using Orion.Application.StoryAppLayer.DTOs;
using Orion.Application.StoryAppLayer.Gateway;

namespace Orion.Application.StoryAppLayer.UseCases.GetStories
{
    public class GetStoriesQueryHandler : IRequestHandler<GetStoriesQuery, IEnumerable<StoryDto>>
    {
        private readonly IStoryRepository _storyRepository;

        public GetStoriesQueryHandler(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<IEnumerable<StoryDto>> Handle(GetStoriesQuery request, CancellationToken cancellationToken)
        {
            var stories = await _storyRepository.GetAsync();
            return stories.Select(s => new StoryDto
            {
                Id = s.Id,
                Text = s.Text,
                Images = s.Images.ToArray()
            });
        }
    }
}
