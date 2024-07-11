using AutoMapper;
using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ForkliftDirectory.Server.Controllers
{
    [EnableCors("AllowClient")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetList()
        {
            var users = await _userRepository.GetListAsync();

            return Ok(users);
        }
    }
}