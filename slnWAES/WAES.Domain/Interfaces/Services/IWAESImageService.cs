using System.Collections.Generic;
using WAES.Domain.Entities;

namespace WAES.Domain.Interfaces.Services
{
    public interface IWAESImageService : IServiceBase<WAESImage>
    {
        IEnumerable<WAESImage> GetAllBySenderId(int idCompare);
    }
}
