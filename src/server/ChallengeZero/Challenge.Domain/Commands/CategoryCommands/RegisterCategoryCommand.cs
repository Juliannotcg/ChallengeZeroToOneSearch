using System;

namespace Challenge.Domain.Commands.CategoryCommands
{
    public class RegisterCategoryCommand : CategoryCommand
    {
        public RegisterCategoryCommand(Guid id, string name )
        {
            Id = id;
            Name = name;
        }
    }
}
