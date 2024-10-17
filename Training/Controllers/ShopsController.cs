using Microsoft.AspNetCore.Mvc;
using Training.Model;
using Training.Service;

namespace Training.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopsController(IService<Shops> service) : ControllerBase 
    {
        private IService<Shops> _service = service;

        [HttpGet(Name = "GetAllShops")]
        public async Task<IEnumerable<Shops?>> Get()
        {
            return await _service.GetAllTs();
        }
        [HttpPost]
        public async Task<Shops> Post([FromBody] Shops shops)
        {
            return await _service.AddT(shops);
        }

        [HttpPut]
        public async Task<Shops> Put([FromBody] Shops shops)
        {
            return await _service.UpdateT(shops);
        }
        [HttpGet("{id}", Name = "GetCowsByID")]
        public async Task<Shops?> Get(Guid id)
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
