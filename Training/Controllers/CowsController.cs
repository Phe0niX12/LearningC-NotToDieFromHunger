using Microsoft.AspNetCore.Mvc;
using Training.DOTs.CowsDTOs;
using Training.Mapper;
using Training.Model;
using Training.Service;

namespace Training.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CowsController(IService<Cow> service) : ControllerBase {
        private IService<Cow> _service = service;
        [HttpGet(Name = "GetAllFarmers")]
        public async Task<IEnumerable<CowDTO>> Get()
        {
            IEnumerable<Cow> cows = await _service.GetAllTs();
            IEnumerable<CowDTO> cowDTOs = cows.ToList().Select(e => e?.toCowDTO());
            return cowDTOs;
        }
        [HttpPost]
        public async Task<Cow> Post([FromBody] Cow cow) {
            return await _service.AddT(cow);
        }

        [HttpPut]
        public async Task<Cow> Put([FromBody] Cow cow)
        {
            return await _service.UpdateT(cow);
        }
        [HttpGet("{id}", Name = "GetFarmersByID")]
        public async Task<Cow?> Get(Guid id)
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
