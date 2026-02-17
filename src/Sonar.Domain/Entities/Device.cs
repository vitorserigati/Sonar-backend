using Sonar.Domain.Primitives;
using Sonar.Domain.ValueTypes.Device;

namespace Sonar.Domain.Entities;

public enum DeviceStatus { ACTIVE, INACTIVE }

public sealed class Device : Entity<Guid>
{
    public DeviceCodeHash DeviceCodeHash { get; private set; }

    public DeviceIdentification Identification { get; private set; }

    public DeviceStatus Status { get; private set; }

    public Device(Guid id, DeviceCodeHash deviceCodeHash, DeviceIdentification deviceIdentification, DeviceStatus status, DateTime createdAtUtc, DateTime? updatedAtUtc) :
        base(id, createdAtUtc, updatedAtUtc)
    {
        DeviceCodeHash = deviceCodeHash;
        Identification = deviceIdentification;
        Status = status;
    }
}
