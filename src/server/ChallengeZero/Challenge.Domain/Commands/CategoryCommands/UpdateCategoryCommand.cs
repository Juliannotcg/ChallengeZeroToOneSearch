using System;

namespace Challenge.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : CategoryCommand
    {
        public UpdateCategoryCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
