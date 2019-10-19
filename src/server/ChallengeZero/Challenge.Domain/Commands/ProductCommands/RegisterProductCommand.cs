using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Commands.ProductCommands
{
    public class RegisterProductCommand : ProductCommand
    {
        public RegisterProductCommand(string name, decimal price, Guid categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

    }
}
