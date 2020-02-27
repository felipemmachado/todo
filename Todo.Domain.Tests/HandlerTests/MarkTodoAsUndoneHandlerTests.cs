using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;
using Xunit;

namespace Todo.Domain.Tests.HandlerTests
{

    public class MarkTodoAsUndoneHandlerTests
    {
        private readonly MarkTodoAsUndoneCommand _validCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid(), "felipemmachado28");
        private readonly MarkTodoAsUndoneCommand _invalidCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid(), "");
        private readonly MarkTodoAsUndoneCommand _invalidCommandUser = new MarkTodoAsUndoneCommand(Guid.NewGuid(), "felipe");
        private readonly MarkTodoAsUndoneHandler _handler = new MarkTodoAsUndoneHandler(new FakeTodoRepository());

        [Fact]
        public void Dado_um_comando_valido_marca_como_desfeito()
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

        [Fact]
        public void Dado_um_usuario_invalido_deve_interromper_a_execucao()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommandUser);
            Assert.False(result.Success);
        }

    }
}