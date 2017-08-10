using WAES.Domain.ValueObjects;

namespace WAES.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ValidationResult { get; }
        bool IsValid();
    }
}
