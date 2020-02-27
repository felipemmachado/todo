using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Xunit;

namespace Todo.Domain.Tests.QueryTests
{
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();

            _items.Add(new TodoItem("Tarefa 1", new DateTime(), "felipemachado"));
            _items.Add(new TodoItem("Tarefa 2", new DateTime(), "felipemachado"));
            _items.Add(new TodoItem("Tarefa 3", new DateTime(), "felipemachado"));
            _items.Add(new TodoItem("Tarefa 1", new DateTime(), "daniellucena"));
            _items.Add(new TodoItem("Tarefa 2", new DateTime(), "daniellucena"));
        }

        [Fact]
        public void Dada_a_consulta_deve_retornar_apenas_dados_do_usuario_felipemachado()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("felipemachado"));

            Assert.True(result.Count() == 3);
        }
    }
}