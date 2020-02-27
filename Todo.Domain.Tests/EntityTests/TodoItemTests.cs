using System;
using Todo.Domain.Entities;
using Xunit;

namespace Todo.Domain.Tests.EntityTests
{

    public class TodoItemTests
    {
        private readonly TodoItem _validTodoItem = new TodoItem("titulo 1",  new DateTime(), "felipemmachado28");

        [Fact]
        public void Dado_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.False(_validTodoItem.Done);
        }
    }
}