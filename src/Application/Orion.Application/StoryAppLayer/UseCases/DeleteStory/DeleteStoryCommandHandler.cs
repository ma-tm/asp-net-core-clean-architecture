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
            var storyDto = new StoryDto
            {
                Id = deletedStory.Id,
                Text = deletedStory.Text
            };
            return storyDto;
        }
    }
}
