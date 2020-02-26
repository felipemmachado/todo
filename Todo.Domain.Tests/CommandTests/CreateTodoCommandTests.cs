using System;
using Todo.Domain.Commands;
using Xunit;

namespace Todo.Domain.Tests.CommandTests
{
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", new DateTime(), "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("titulo 1", new DateTime(), "felipemmachado28");

        [Fact]
        public void Dado_um_commando_invalido()
        {
            _invalidCommand.Validate();
            Assert.False(_invalidCommand.Valid);
        }

        [Fact]
        public void Dado_um_commando_valido()
        {
            _validCommand.Validate();
            Assert.True(_validCommand.Valid);
        }
    }
}
