using MediatR;
using Orion.Application.StoryAppLayer.DTOs;
using Orion.Application.StoryAppLayer.Gateway;
using Orion.Application.StoryAppLayer.UseCases.CreateStory;
using Orion.Domain.StoryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Application.StoryAppLayer.UseCases.UpdateStory
{
    public class UpdateStoryCommandHandler : IRequestHandler<UpdateStoryCommand, StoryDto>
    {
        private readonly IStoryRepository _storyRepository;

        public UpdateStoryCommandHandler(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
        {       
            var story = await _storyRepository.GetByIdAsync(request.Id);
            story.Text = request.Text;

            var updatedStory = await _storyRepository.UpdateAsync(story);
            var storyDto = new StoryDto
            {
                Id = updatedStory.Id,
                Text = updatedStory.Text
            };
            return storyDto;
        }
    }
}
