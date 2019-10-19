using System;

namespace Challenge.Domain.Commands.ProductCommands
{
    public class RemoveProductCommand : ProductCommand
    {
        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
