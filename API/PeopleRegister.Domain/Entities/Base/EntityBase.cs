using Flunt.Notifications;

namespace PeopleRegister.Domain.Entities;

public abstract class EntityBase : Notifiable<Notification>
{
  public Guid Id { get; private set; }

  protected EntityBase()
  {
    Id = Guid.NewGuid();
  }
}