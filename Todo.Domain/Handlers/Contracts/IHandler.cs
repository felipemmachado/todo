using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    // T vai gerenciar mais de um comando, T significa generico
    public interface IHandler<T> where T : ICommand
    {
        // sempre retorna um ICommandResult de um metodo Handle que recebe um comando
        IcommandResult Handle(T command);
    }
}