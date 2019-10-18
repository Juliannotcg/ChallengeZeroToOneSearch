using Challenge.Domain.Core.Models;
using FluentValidation;


namespace Challenge.Domain.Models
{
    public class Product : Identity<Product>
    {
        public Product(string name,
                       decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public virtual Category Category { get; private set; }


        public void AddCategory(Category category)
        {
            if (!category.IsValid()) return;
            Category = category;
        }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidatePrice();
            ValidationResult = Validate(this);
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(2, 150).WithMessage("O nome do produto precisa ter entre 2 e 150 caracteres");
        }

        private void ValidatePrice()
        {
            RuleFor(c => c.Price)
                .ExclusiveBetween(1, 50000)
                .WithMessage("O valor deve estar entre 1.00 e 50.000");
        }
    }
}
