using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
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

        public IcommandResult Handle(UpdateTodoCommand command)
        {
            // fail fast validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que algo deu errado.", command.Notifications);

            // recuperar o TodoItem (rehitraçao)
            var todo = _repository.GetById(command.Id, command.User);

            // atualiza o titulo
            todo.UpdateTitle(command.Title);

            // salva no banco
            _repository.Update(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }

        public IcommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // fail fast validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que algo deu errado.", command.Notifications);

            // recuperar o TodoItem (rehitraçao)
            var todo = _repository.GetById(command.Id, command.User);

            // seta como concluido
            todo.MarkAsDone();

            // salva no banco
            _repository.Update(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }

        public IcommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // fail fast validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que algo deu errado.", command.Notifications);

            // recuperar o TodoItem (rehitraçao)
            var todo = _repository.GetById(command.Id, command.User);

            // seta desfeito
            todo.MarkAsUndone();

            // salva no banco
            _repository.Update(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }
    }
}