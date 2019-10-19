using System;

namespace Challenge.Domain.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : CategoryCommand
    {
        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
