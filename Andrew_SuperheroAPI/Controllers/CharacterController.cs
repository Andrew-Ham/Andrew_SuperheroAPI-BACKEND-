using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Andrew_SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CharacterController : ControllerBase
    {
        private readonly ICharacterAssemble _characterService;

        public CharacterController(ICharacterAssemble characterAssemble)
        {
            _characterService = characterAssemble;
        }



        [HttpGet]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 120)]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            return Ok(await _characterService.GetCharacters());
        }

        [HttpGet]
        [Route("CharacterName")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 120)]
        public async Task<ActionResult<List<Character>>> GetCharacterByName(string name)
        {
            var findCharacter = await _characterService.GetCharacterByName(name);
            if (findCharacter == null)
            {
                return BadRequest("The character does NOT exists!");
            }
            return Ok(await _characterService.GetCharacterByName(name));
        }



        [HttpGet]
        [Route("HighestPaid")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 120)]
        public async Task<ActionResult<Character>> GetHighestPaidCharacter()
        {
            return Ok(await _characterService.GetHighestSalaryChracter());
        }

        [HttpPost]
        [Route("Character")]
        public async Task<ActionResult<IList<CharacterDTO>>> AddCharacter(Character request)
        {
            var findCharacter = await _characterService.GetCharacterByName(request.Name);
            if (findCharacter == null)
            {
                var characterDTO = new CharacterDTO()
                {
                    Name = request.Name,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Age = request.Age,
                    Location = request.Location,
                    Strength = request.Strength,
                    HoursWorked = request.HoursWorked,
                    HourlyRate = request.HourlyRate,
                };
                return Ok(await _characterService.PostCharacter(characterDTO));
            }
            else
            {
                return BadRequest("The character already exists!");
            }
        }

        [HttpPut]
        [Route("CharacterUpdate")]
        public async Task<ActionResult<IList<CharacterDTO>>> UpdateCharacter(Character request)
        {
            var findCharacter = await _characterService.GetCharacterByName(request.Name); //find the character we want
            if (findCharacter == null)
            {
                return BadRequest("The character you are looking for does not exist!");
            }
            else
            {
                return Ok(await _characterService.UpdateCharacter(request));
            }
        }

        [HttpDelete]
        [Route("CharacterDelete")]
        public async Task<ActionResult<IList<CharacterDTO>>> DeleteCharacter(string name)
        {
            var findCharacter = await _characterService.GetCharacterByName(name);
            if (findCharacter == null)
            {
                return BadRequest("The character you are trying to delete does not exist");
            }
            else
            {
                return Ok(await _characterService.DeleteCharacter(findCharacter));
            }
        }

        [HttpGet]
        [Route("ProcessCharacterPay")]
        public async Task<ActionResult<IList<CharacterPay>>> ProcessCharacterPay()
        {
            return Ok(await _characterService.GetCharacterPays());
        }

        [HttpGet]
        [Route("PokemonFight")]
        public async Task<ActionResult<string>> GetPokemonFight(string pokemonName)
        {
            return Ok(await _characterService.PokemonBattle(pokemonName));
        }

    }
}
