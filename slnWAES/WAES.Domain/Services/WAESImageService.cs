using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAES.Domain.Entities;
using WAES.Domain.Interfaces.Repositories;
using WAES.Domain.Interfaces.Services;

namespace WAES.Domain.Services
{
    public class WAESImageService : ServiceBase<WAESImage>, IWAESImageService
    {
        public WAESImageService(IRepositoryBase<WAESImage> repository) : base(repository)
        {
        }

        public IEnumerable<WAESImage> GetAllBySenderId(int idCompare)
        {
            throw new NotImplementedException();
        }
    }
}
