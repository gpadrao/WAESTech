using WAES.Domain.Entities;
using WAES.Domain.Interfaces.Repositories;

namespace WAES.Infra.Data.Repository
{
    /// <summary>
    /// Class that specializes the WAESImage repository methods if necessary
    /// </summary>
    public class WAESImageRepository : RepositoryBase<WAESImage>, IWAESImageRepository
    {
    }
}
