using Sonar.Domain.Primitives;
using Sonar.Domain.ValueTypes.User;

namespace Sonar.Domain.Entities;


public sealed class User : Entity<Guid>
{
    public UserName Name { get; private set; }

    public UserSurname Surname { get; private set; }

    public UserEmail Email { get; private set; }

    public UserPassword PasswordHash { get; private set; }

    private User(Guid id, UserName name, UserSurname surname, UserEmail email, UserPassword passwordHash, DateTime createdAtUtc, DateTime? updatedAtUtc) :
        base(id, createdAtUtc, updatedAtUtc)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PasswordHash = passwordHash;
    }

    public static User Create(string name, string surname, string email, string passwordHash, DateTime? updatedAtUtc)
    {
        return new(
            id: Guid.CreateVersion7(),
            name: UserName.From(name),
            surname: UserSurname.From(surname),
            email: UserEmail.From(email),
            passwordHash: UserPassword.From(passwordHash),
            createdAtUtc: DateTime.UtcNow,
            updatedAtUtc: updatedAtUtc);
    }

    public static User Restore(Guid id, string name, string surname, string email, string passwordHash, DateTime createdAtUtc, DateTime updatedAtUtc)
    {

        return new(
            id: id,
            name: UserName.From(name),
            surname: UserSurname.From(surname),
            email: UserEmail.From(email),
            passwordHash: UserPassword.From(passwordHash),
            createdAtUtc: DateTime.UtcNow,
            updatedAtUtc: updatedAtUtc);
    }
}
