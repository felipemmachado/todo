using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.API.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] CreateTodoHandler handler
            )
        {
            command.User = "felipemachado28";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done/{id:guid}")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] MarkTodoAsDoneHandler handler,
            Guid id
            )
        {
            if(id != command.Id)
                return new GenericCommandResult(false, "Id não encontrado", false);

            command.User = "felipemachado28";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone/{id:guid}")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkTodoAsUndoneCommand command,
            [FromServices] MarkTodoAsUndoneHandler handler,
            Guid id
            )
        {
            if(id != command.Id)
                return new GenericCommandResult(false, "Id não encontrado", false);

            command.User = "felipemachado28";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:guid}")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] UpdateTodoHandler handler,
            Guid id
            )
        {
            if(id != command.Id)
                return new GenericCommandResult(false, "Id não encontrado", false);

            command.User = "felipemachado28";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone("felipemachado28");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllUndone("felipemachado28");
        }

        [Route("period/{date:DateTime}/{done:bool}")]
        [HttpGet]
        public IEnumerable<TodoItem> GetByPeriod(
            [FromServices] ITodoRepository repository, 
            DateTime date, 
            bool done)
        {
            return repository.GetAllPeriod("felipemmachado28", date.Date, done);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll("felipemachado28");
        }
    }
}