using Microsoft.AspNetCore.Mvc;
using Training.Model;
using Training.Service;

namespace Training.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CowsController(IService<Cow> service): ControllerBase {
        private IService<Cow> _service = service;
        [HttpGet]
        public async Task<IEnumerable<Cow>> Get() {
            return await _service.GetAllTs();
        }
        [HttpPost]
        public async Task<Cow> Post([FromBody] Cow cow) {
            return await _service.AddT(cow);
        }
    }
}
