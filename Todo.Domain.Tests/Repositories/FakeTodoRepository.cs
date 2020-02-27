using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{

    public class FakeTodoRepository : ITodoRepository
    {
        private List<TodoItem> _items;

        public FakeTodoRepository()
        {
            _items = new List<TodoItem>();

            _items.Add(new TodoItem("Tarefa 1", new DateTime(), "felipemachado"));
            _items.Add(new TodoItem("Tarefa 2", new DateTime(), "felipemachado"));
            _items.Add(new TodoItem("Tarefa 3", new DateTime(), "felipemachado"));
            _items.Add(new TodoItem("Tarefa 1", new DateTime(), "daniellucena"));
            _items.Add(new TodoItem("Tarefa 2", new DateTime(), "daniellucena"));
        }

        public void Create(TodoItem todo)
        {
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _items.Where(x => x.User == user);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _items.Where(x => x.User == user && x.Done);
        }

        public IEnumerable<TodoItem> GetAllPeriod(string user, DateTime date, bool done)
        {
            return _items.Where(x => x.User == user && x.Date.Date == date && x.Done == done);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _items.Where(x => x.User == user && !x.Done);
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