using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FluentValidation;

namespace FinalProject.Application.Validators.Users
{
    public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandRequestValidator()
        {
            RuleFor(p => p.UserCreateDto.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter name..")
                .MaximumLength(30)
                    .WithMessage("Name cannot be longer than 30 character..");

            RuleFor(p => p.UserCreateDto.Surname)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter Surname..")
                .MaximumLength(20)
                    .WithMessage("Surname cannot be longer than 20 character..");

            RuleFor(p => p.UserCreateDto.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter Email..");

            RuleFor(p => p.UserCreateDto.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter brand..")
                .MaximumLength(20)
                    .WithMessage("Password cannot be longer than 20 character..")
                .MinimumLength(8)
                    .WithMessage("Password cannot be shorter than 8 characters..");
                    


        }
    }
}
