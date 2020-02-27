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
            _items[0].MarkAsDone();

            _items.Add(new TodoItem("Tarefa 2", new DateTime(2010, 02, 02, 00, 00, 00), "felipemachado"));
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

        [Fact]
        public void Dada_a_consulta_deve_retonar_apenas_tarefas_completas_do_usuario_felipemachado()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("felipemachado"));
            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void Dada_a_consulta_deve_retonar_apenas_tarefas_incompletas_do_usuario_felipemachado()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("felipemachado"));
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void Dada_a_consulta_deve_retonar_tarefas_incompletas_de_um_periodo_do_usuario_felipemachado()
        {
            var result = _items.AsQueryable()
                .Where(
                    TodoQueries.GetByPeriod(
                        "felipemachado", 
                        new DateTime(2010, 02, 02, 00, 00, 00), 
                        false)
                    );

          Assert.True(result.Count() == 1);
        }

        [Fact]
        public void Dada_a_consulta_deve_retonar_tarefas_completas_de_um_periodo_do_usuario_felipemachado()
        {
            var result = _items.AsQueryable()
                .Where(
                    TodoQueries.GetByPeriod(
                        "felipemachado", 
                        new DateTime(2010, 02, 02, 00, 00, 00), 
                        true)
                    );

           Assert.True(result.Count() == 0);
        }
    }
}