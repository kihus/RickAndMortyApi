using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Models.Dtos.Character;
using RickAndMorty.Models.Dtos.Page;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet()]
        public async Task<ActionResult<CharacterResponseDto>> GetAll([FromQuery] PageDto page)
        {
            try
            {
                var characters = await _characterService.GetAll(page);

                if (characters is null)
                    return NotFound();

                return Ok(characters);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{ids}")]
        public async Task<ActionResult<List<CharacterDto>>> GetManyById(string ids)
        {
            try
            {
                var characters = await _characterService.GetManyById(ids);

                return (characters);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("filter/")]
        public async Task<ActionResult<List<CharacterDto>>> GetFilter([FromQuery] CharacterFilter filter)
        {
            try
            {
                var characterFilter = await _characterService.GetByFilter(filter);

                return Ok(characterFilter);   
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
