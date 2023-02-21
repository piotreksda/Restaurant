using System;
using FluentValidation;

namespace Restaurant.Application.TestEntities.Commands.CreateTestEntity
{
    public class CreateTestEntityCommandValidator : AbstractValidator<CreateTestEntityCommand>
    {
        public CreateTestEntityCommandValidator()
        {
            RuleFor(v => v.SeatsCount)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}

