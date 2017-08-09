using WAES.Domain.Entities;
using WAES.Domain.Interfaces.Repositories;
using WAES.Infra.Data.Context;

namespace WAES.Infra.Data.Repository
{
    public class WAESImageRepository : RepositoryBase<WAESImage, WAESModelContext>, IWAESImageRepository
    {
    }
}
