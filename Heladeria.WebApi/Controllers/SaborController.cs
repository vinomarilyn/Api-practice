using Heladeria.Models;
using Heladeria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Heladeria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaborController : ControllerBase
    {
        private readonly SaboresService _saborService;
        public SaborController() 
        {
            _saborService = new SaboresService();
        }
        [HttpGet()]
        public List<Sabor> GetAll()
        {
            return _saborService.GetAll();
        }
    }
}
