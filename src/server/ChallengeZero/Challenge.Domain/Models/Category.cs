using Challenge.Domain.Core.Models;
using FluentValidation;

namespace Challenge.Domain.Models
{
    public class Category : Identity<Category>
    {
        public Category(string name)
        {
            Name = name;
        }

        private Category(){}

        public string Name { get; private set; }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidationResult = Validate(this);
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
                .Length(2, 150).WithMessage("O nome da categoria precisa ter entre 2 e 150 caracteres");
        }
    }
}
