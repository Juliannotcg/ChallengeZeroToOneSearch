using Challenge.Domain.Core.Models;
using Challenge.Domain.Core.Resources;
using FluentValidation;
using System;

namespace Challenge.Domain.Models
{
    public class Product : Identity<Product>
    {
        public Product(string name,
                       decimal price,
                       Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        private Product(){}

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid? CategoryId { get; private set; }

        public virtual Category Category { get; private set; }

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
                .NotEmpty().WithMessage(ErrorsValidations.NameNullOrEmpty)
                .Length(2, 150).WithMessage(ErrorsValidations.NameSize);
        }

        private void ValidatePrice()
        {
            RuleFor(c => c.Price)
                .ExclusiveBetween(1, 50000)
                .WithMessage("Must value is between 1.00 and 50.000");
        }

        public static class ProductFactory
        {
            public static Product NewProductFull(Guid id, string name, decimal price, Guid categoryId)
            {
                var product = new Product()
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    CategoryId = categoryId
                };

                return product;
            }
        }
    }
}
