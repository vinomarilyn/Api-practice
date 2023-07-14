using Heladeria.DataAccess;
using Heladeria.Models;

namespace Heladeria.Services
{
    public class SaboresService
    {
        private readonly SaboresRepository _saboresRepository;
        public SaboresService()
        {
            _saboresRepository = new SaboresRepository();
        }
        public List<Sabor> GetAll()
        {
            return _saboresRepository.GetAll();
        }
    }
}