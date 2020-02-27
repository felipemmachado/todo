using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{

    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            var todo = new TodoItem("Titulo 1", new DateTime(), "felipemmachado28");

            return todo;
        }

        public void Update(TodoItem todo)
        {
        }
    }

}