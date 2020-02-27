using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;
using Xunit;

namespace Todo.Domain.Tests.HandlerTests
{
    public class CreateTodoHandlerTests
    {

        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", new DateTime(), "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("titulo 1", new DateTime(), "felipemmachado28");
        private readonly CreateTodoHandler _handler = new CreateTodoHandler(new FakeTodoRepository());


        [Fact]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            // MOQ
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.False(result.Success);
        }

        [Fact]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.True(result.Success);
        }

    }

}