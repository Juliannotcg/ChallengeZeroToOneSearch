using System;

namespace Challenge.Domain.Commands.ProductCommands
{
    public class RegisterProductCommand : ProductCommand
    {
        public RegisterProductCommand(Guid id, string name, decimal price, Guid categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
