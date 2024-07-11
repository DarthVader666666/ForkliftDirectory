using AutoMapper;
using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Interfaces;
using ForkliftDirectory.Server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ForkliftDirectory.Server.Controllers
{
    [EnableCors("AllowAll")]
    [ApiController]
    public class ForkliftsController : ControllerBase
    {
        private readonly IRepository<Forklift> _forkliftRepository;
        private readonly IMapper _mapper;

        public ForkliftsController(IRepository<Forklift> forkliftRepository, IMapper mapper)
        {
            _forkliftRepository = forkliftRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetList() 
        {
            var forklifts = _mapper.Map<IEnumerable<ForkliftIndexModel>>(await _forkliftRepository.GetListAsync());

            return Ok(forklifts);
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Find([FromQuery]string? number)
        {
            var forklifts = _mapper.Map<IEnumerable<ForkliftIndexModel>>(await _forkliftRepository.GetListByAsync(number));

            return Ok(forklifts);
        }

        [HttpDelete]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Delete([FromQuery] int? forkliftId)
        {
            var forklifts = await _forkliftRepository.DeleteAsync(forkliftId);

            return Ok(forklifts);
        }
    }
}
