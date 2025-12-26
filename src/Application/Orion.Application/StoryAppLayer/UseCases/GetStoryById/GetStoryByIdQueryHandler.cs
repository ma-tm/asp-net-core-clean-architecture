using MediatR;
using Orion.Application.StoryAppLayer.DTOs;
using Orion.Application.StoryAppLayer.Gateway;
using Orion.Application.StoryAppLayer.UseCases.CreateStory;
using Orion.Application.StoryAppLayer.UseCases.UpdateStory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            var storyDto = new StoryDto
            {
                Id = story.Id,
                Text = story.Text
            };
            return storyDto;
        }
    }
}
