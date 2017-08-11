using System.Collections.Generic;
using System.Linq;
using WAES.Domain.Entities;
using WAES.Domain.Interfaces.Repositories;
using WAES.Domain.Interfaces.Services;

namespace WAES.Domain.Services
{
    /// <summary>
    /// Specializing methods for the WAESImage entity.
    /// These methods are only allowed to access the repository, again, no business rules are allowed here.
    /// </summary>
    public class WAESImageService : ServiceBase<WAESImage>, IWAESImageService
    {
        private readonly IWAESImageRepository _waesImageRepository;
       
        public WAESImageService(IRepositoryBase<WAESImage> repository,
                                IWAESImageRepository waesImageRepository) : base(repository)
        {
            _waesImageRepository = waesImageRepository;
        }

        public IEnumerable<WAESImage> GetAllBySenderId(int idCompare)
        {
            return _waesImageRepository.Find(x => x.IdCompare.Equals(idCompare)).ToList();
        }

        public WAESImage GetBySenderIdAndSide(int idCompare, int side)
        {
            return _waesImageRepository.Find(x => x.IdCompare.Equals(idCompare) && x.Side.Equals(side)).FirstOrDefault();
        }
    }
}
