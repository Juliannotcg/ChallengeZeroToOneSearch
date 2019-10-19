using Challenge.Domain.Core.Commands;
using System;

namespace Challenge.Domain.Commands.ProductCommands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid CategoryId { get; protected set; }
    }
}
