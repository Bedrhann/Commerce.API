using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FluentValidation;

namespace FinalProject.Application.Validators.Products
{
    public class UpdateProductCommandRequestValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandRequestValidator()
        {
            RuleFor(p => p.ProductDto.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter name..")
                .MaximumLength(100)
                    .WithMessage("Name cannot be longer than 100 character..");
            RuleFor(p => p.ProductDto.Description)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Please enter description..")
                .MaximumLength(500)
                    .WithMessage("Description cannot be longer than 100 letters");
            RuleFor(p => p.ProductDto.Color)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter color..");
            RuleFor(p => p.ProductDto.Brand)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter brand..");
            RuleFor(p => p.ProductDto.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter brand..");
        }
    }
}
