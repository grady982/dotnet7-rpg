using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    // ControllerBase
    // this is basic mvc controller without view support,
    // since we're building an API here, we don't need view support

    // ApiController
    // when we add this attribute to the controller, it enables serveral API specific

    // Route
    // this means that this controller can be accessed by "api/Character"
    // the part of the name of this class that comes before controller

    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        public ICharacterService _characterService { get; }

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;

        }

        // add HttpGet attribute to indicate
        // bellow attributes seetings equal [HttpGet("GetAll")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetList()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        [Route("AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto data)
        {
            return Ok(await _characterService.AddCharacter(data));
        }

        [HttpPut]
        [Route("UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacter(UpdateCharacterDto data)
        {
            var result = await _characterService.UpdateCharacter(data);
            if (result.Data is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteCharacter/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var result = await _characterService.DeleteCharacter(id);
            if (result.Data is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}