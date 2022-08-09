using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Models;
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
        public async Task<ActionResult<List<Character>>> Get() // Having Task<IActionResult> defines a contract that represents the result of an action method which will not display scheme or data
        {
            return Ok(_characterService.GetCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> Get(int id) // Having Task<IActionResult> defines a contract that represents the result of an action method which will not display scheme or data
        {
            var character = _characterService.GetCharacters().Find(element => element.Id == id); //find character we want 
            if (character == null)
                return BadRequest("The character you are looking for does not exist!");
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character request)
        {
            var character = _characterService.GetCharacters().Find(element => element.Id == request.Id);
            if (character != null)
                return BadRequest("This unique ID already exists, Please use different ID");
            return Ok(_characterService.PostSuperHero(request));
        }


        [HttpPut]
        public async Task<ActionResult<List<Character>>> UpdateCharacter(Character request)
        {
            var character = _characterService.GetCharacters().Find(element => element.Id == request.Id); //find the character we want
            if (character == null)
                return BadRequest("The character you are looking for does not exist!");

            character.Name = request.Name;
            character.FirstName = request.FirstName;
            character.LastName = request.LastName;
            character.Age = request.Age;

            return Ok(_characterService.UpdateSuperHero(request));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Character>>> DeleteCharacter(int id)
        {
            var character = _characterService.GetCharacters().Find(element => element.Id == id); //find the character we want
            if (character == null)
                return BadRequest("The character you are looking for does not exist!");

            _characterService.DeleteCharacter(id);
            return Ok(_characterService.GetCharacters());

        }

        [HttpGet]
        [Route("/pokemon/{pokemonName}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] //When status code 200, it product response type of string
        public async Task<IActionResult> PokemonFight([Required] string pokemonName)
        {
            return new OkObjectResult(await _characterService.PokemonBattle(pokemonName));
        }

    }
}
