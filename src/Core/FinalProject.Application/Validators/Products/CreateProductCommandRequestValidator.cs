using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FluentValidation;

namespace FinalProject.Application.Validators.Products
{
    public class CreateProductCommandRequestValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandRequestValidator()
        {
            RuleFor(p => p.ProductCreateDto.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter name..")
                .MaximumLength(100)
                    .WithMessage("Name cannot be longer than 100 character..");
            RuleFor(p => p.ProductCreateDto.Description)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Please enter description..")
                .MaximumLength(500)
                    .WithMessage("Description cannot be longer than 100 letters");
            RuleFor(p => p.ProductCreateDto.Color)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter color..");
            RuleFor(p => p.ProductCreateDto.Brand)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter brand..");
            RuleFor(p => p.ProductCreateDto.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter brand..");
        }
    }
}
