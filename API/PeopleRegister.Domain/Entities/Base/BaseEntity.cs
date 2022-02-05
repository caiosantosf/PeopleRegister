using Flunt.Notifications;

namespace PeopleRegister.Domain.Entities;

public abstract class BaseEntity : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}