using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;
using Xunit;

namespace Todo.Domain.Tests.HandlerTests
{

    public class MarkTodoAsDoneHandlerTests
    {
        private readonly MarkTodoAsDoneCommand _validCommand = new MarkTodoAsDoneCommand(Guid.NewGuid(), "felipemmachado28");
        private readonly MarkTodoAsDoneCommand _invalidCommand = new MarkTodoAsDoneCommand(Guid.NewGuid(), "");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [Fact]
        public void Dado_um_comando_valido_marca_como_feito()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.True(result.Success);
        }


        [Fact]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.False(result.Success);
        }

    }
}