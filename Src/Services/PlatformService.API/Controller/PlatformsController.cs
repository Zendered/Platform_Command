using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.API.Data.Repository;
using PlatformService.API.Dtos;
using PlatformService.API.Models;

namespace PlatformService.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            Console.WriteLine("--> Getting Platforms");
            var platformItems = _platformRepo.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = _platformRepo.GetPlatformById(id);

            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();

        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platform)
        {

            if (platform is null)
            {
                return BadRequest();
            }

            var newPlatform = _mapper.Map<Platform>(platform);

            _platformRepo.CreatePlatform(newPlatform);
            _platformRepo.SaveChanges();

            var res = _mapper.Map<PlatformReadDto>(newPlatform);

            return CreatedAtRoute(nameof(GetPlatformById), new { id = res.Id }, res);
        }
    }
}
