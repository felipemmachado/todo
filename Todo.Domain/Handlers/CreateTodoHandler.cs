using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class CreateTodoHandler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public CreateTodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public IcommandResult Handle(CreateTodoCommand command)
        {
            // fail fast validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que algo deu errado.", command.Notifications);

            // gera um todoItem
            TodoItem todoItem = new TodoItem(command.Title, command.Date, command.User);

            // Salva no banco
            _repository.Create(todoItem);

            return new GenericCommandResult(true, "Tarefa salva", todoItem);
        }
    }
}