using FluentValidation;
using FluentValidation.Results;
using System;

namespace Challenge.Domain.Core.Models
{
    public abstract class Identity<T> : 
        AbstractValidator<T> where T : 
        Identity<T>
    {
        protected Identity() => ValidationResult = new ValidationResult();

        public Guid Id { get; protected set; }

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }
    }
}
