using FluentValidation;

namespace Orion.Application.StoryAppLayer.UseCases.CreateStory
{
    public class CreateStoryCommandValidator : AbstractValidator<CreateStoryCommand>
    {
        public CreateStoryCommandValidator()
        {
            RuleFor(c => c.Text).NotNull().NotEmpty();
        }
    }
}
