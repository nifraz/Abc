using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;

namespace ABC.CarTraders.Persistence.Repositories
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(AbcCarTradersContext context) : base(context)
        {

        }
    }
}
