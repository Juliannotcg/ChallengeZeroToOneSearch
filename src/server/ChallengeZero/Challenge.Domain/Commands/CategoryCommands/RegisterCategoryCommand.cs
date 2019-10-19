using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Commands.CategoryCommands
{
    public class RegisterCategoryCommand : CategoryCommand
    {
        public RegisterCategoryCommand(string name )
        {
            Name = name;
        }
    }
}
