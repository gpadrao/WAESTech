using WAES.Domain.ValueObjects;

namespace WAES.Domain.Interfaces.Validation
{
    /// <summary>
    /// Interface used to obligate some entities to validate their properties before be inserted into database
    /// </summary>
    public interface ISelfValidator
    {
        bool IsValid();
    }
}
