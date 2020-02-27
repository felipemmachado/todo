using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;
using Xunit;

namespace Todo.Domain.Tests.HandlerTests
{
    public class UpdateTodoHandlerTests
    {

        private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand("Titulo 2", Guid.NewGuid(), "felipemmachado28");
        private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand("", Guid.NewGuid(), "");
        private readonly UpdateTodoCommand _invalidCommandUser = new UpdateTodoCommand("Titulo 2", Guid.NewGuid(), "felipe");
        private readonly UpdateTodoHandler _handler = new UpdateTodoHandler(new FakeTodoRepository());

        [Fact]
        public void Dado_um_comando_valido_atualiza_o_todo()
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