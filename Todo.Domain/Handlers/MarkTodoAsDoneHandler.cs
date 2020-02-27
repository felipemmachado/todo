using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class MarkTodoAsDoneHandler : Notifiable, IHandler<MarkTodoAsDoneCommand>
    {
        private readonly ITodoRepository _repository;

        public MarkTodoAsDoneHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public IcommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // fail fast validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que algo deu errado.", command.Notifications);

            // recuperar o TodoItem (rehitraçao)
            var todo = _repository.GetById(command.Id, command.User);

            if(todo == null)
                return new GenericCommandResult(false, "Ops, tarefa não encontrada.",  null);

            // seta como concluido
            todo.MarkAsDone();

            // salva no banco
            _repository.Update(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }
    }
}