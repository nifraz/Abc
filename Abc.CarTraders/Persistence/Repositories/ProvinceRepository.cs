using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;

namespace ABC.CarTraders.Persistence.Repositories
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        public ProvinceRepository(AbcCarTradersContext context) : base(context)
        {

        }
    }
}
