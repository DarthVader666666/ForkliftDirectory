using AutoMapper;
using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Interfaces;
using ForkliftDirectory.Server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ForkliftDirectory.Server.Controllers
{
    [EnableCors("AllowClient")]
    [ApiController]
    public class MalfunctionsController : ControllerBase
    {
        private readonly IRepository<Malfunction> _malfunctionRepository;
        private readonly IMapper _mapper;

        public MalfunctionsController(IRepository<Malfunction> malfunctionRepository, IMapper mapper)
        {
            _malfunctionRepository = malfunctionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetList()
        {
            var forklifts = _mapper.Map<IEnumerable<MalfunctionIndexModel>>(await _malfunctionRepository.GetListAsync());

            return Ok(forklifts);
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Find([FromQuery] int? forkliftId)
        {
            var malfunctions = await _malfunctionRepository.GetListByAsync(forkliftId);
            IEnumerable<MalfunctionIndexModel>? models = null;

            try { 
               models = _mapper.Map<IEnumerable<MalfunctionIndexModel>>(malfunctions);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return Ok(models);
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Insert([FromBody] MalfunctionInsertModel malfunctionModel)
        {
            var newMalfunction = _mapper.Map<Malfunction>(malfunctionModel);

            var result = await _malfunctionRepository.CreateAsync(newMalfunction);

            return Ok(result);
        }

        [HttpPut]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Update([FromBody] MalfunctionUpdateModel malfunctionModel)
        {
            var newMalfunction = _mapper.Map<Malfunction>(malfunctionModel);

            var result = await _malfunctionRepository.UpdateAsync(newMalfunction);

            return Ok(result);
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult GetTime()
        {
            var time = DateTime.UtcNow.AddHours(3).ToString("yyyy-MM-ddTHH:mm");

            return Ok(new { startTime = time });
        }

        [HttpDelete]
        [Route("[controller]/[action]/{malfunctionId:int}")]
        public async Task<IActionResult> Delete(int? malfunctionId)
        {
            var result = await _malfunctionRepository.DeleteAsync(malfunctionId);

            return Ok(result);
        }
    }
}
