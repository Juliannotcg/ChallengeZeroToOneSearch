using Challenge.Domain.Core.Models;
using FluentValidation;
using System;

namespace Challenge.Domain.Models
{
    public class Category : Identity<Category>
    {
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        private Category(){}

        public string Name { get; private set; }

        public virtual Product Product { get; private set; }

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

        public static class CategoryFactory
        {
            public static Category NewCategoryFull(Guid id, string name)
            {
                var category = new Category()
                {
                    Id = id,
                    Name = name,
                };

                return category;
            }
        }
    }
}
