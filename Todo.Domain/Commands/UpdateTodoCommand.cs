using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand () { }

        public UpdateTodoCommand(string title, Guid id, string user)
        {
            Title = title;
            Id = id;
            User = user;
        }

        public string Title { get; set; }
        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "O titulo tem que ser maior que 3 caracteres.")
                .HasMinLen(User, 6, "User", "Usuário inválido!")
            );
        }
    }
}