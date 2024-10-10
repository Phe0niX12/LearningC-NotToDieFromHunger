using Microsoft.AspNetCore.Mvc;
using Training.Model;
using Training.Service;

namespace Training.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FarmersController(IService<Farmer> service): ControllerBase {
        private IService<Farmer> _service = service;
        [HttpGet(Name = "GetAllCows")]
        public async Task<IEnumerable<Farmer>> Get()
        {
            return await _service.GetAllTs();
        }
        [HttpPost]
        public async Task<Farmer> Post([FromBody] Farmer farmer)
        {
            return await _service.AddT(farmer);
        }

        [HttpPut]
        public async Task<Farmer> Put([FromBody] Farmer farmer)
        {
            return await _service.UpdateT(farmer);
        }
        [HttpGet("{id}", Name = "GetCowsByID")]
        public async Task<Farmer?> Get(Guid id)
        {
            return await _service.GetTById(id);
        }
        [HttpPatch("delete/{id}")]
        public async Task Patch(Guid id)
        {
            await _service.DeleteWithoutDeleting(id);
        }
    }
    
}
