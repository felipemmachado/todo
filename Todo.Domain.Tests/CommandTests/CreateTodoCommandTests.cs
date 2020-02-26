using System;
using Xunit;

namespace Todo.Domain.Tests.CommandTests
{
    public class CreateTodoCommandTests
    {
        [Fact]
        public void Dado_um_commando_invalido()
        {
            Assert.Equal(1, 2);
        }

        [Fact]
        public void Dado_um_commando_valido()
        {
            Assert.Equal(1, 2);
        }
    }
}
