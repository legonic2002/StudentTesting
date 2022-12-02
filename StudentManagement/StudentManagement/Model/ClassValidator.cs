using FluentValidation;
using ShoppingWebAPI.EFcore;

namespace ShoppingWebAPI.Model
{
    public class ClassValidator : AbstractValidator<ClassModel>
    {
        public ClassValidator()
        {
            RuleFor(p => p.tern).NotEmpty().WithMessage("Please ensure that you have entered your tern") ;
            RuleFor(p => p.cousera).NotEmpty().WithMessage("Please ensure that you have entered your cousera");
        }
    }
}
