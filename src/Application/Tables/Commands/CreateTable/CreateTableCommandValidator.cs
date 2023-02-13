using System;
using FluentValidation;

namespace Restaurant.Application.Tables.Commands.CreateTable
{
	public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
		public CreateTableCommandValidator()
		{
            RuleFor(v => v.SeatsCount)
                .NotEmpty()
                .GreaterThan(0);
        }
	}
}

