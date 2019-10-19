using Challenge.Domain.Core.Commands;
using System;

namespace Challenge.Domain.Commands.CategoryCommands
{
    public abstract class CategoryCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}