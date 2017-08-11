using System.Collections.Generic;
using WAES.Domain.Entities;

namespace WAES.Domain.Interfaces.Services
{
    /// <summary>
    /// Specializing methods to manipulate the WAESImage entity.
    /// </summary>
    public interface IWAESImageService : IServiceBase<WAESImage>
    {
        IEnumerable<WAESImage> GetAllBySenderId(int idCompare);
        WAESImage GetBySenderIdAndSide(int idCompare, int side);
    }
}
