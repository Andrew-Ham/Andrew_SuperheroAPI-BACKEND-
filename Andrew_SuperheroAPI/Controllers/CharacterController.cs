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
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 120)]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            return Ok(await _characterService.GetCharacters());
        }

        //[HttpGet]
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 120)]


        //[HttpGet]
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        //public async Task<ActionResult<List<CharacterDTO>>> Get() // Having Task<IActionResult> defines a contract that represents the result of an action method which will not display scheme or data
        //{
        //    // return Ok(_characterService.GetCharacters());
        //    return Ok(await this.context.characters.ToListAsync());
        //}

        //[HttpGet("{id}")]
        //[ResponseCache(CacheProfileName = "120SecondsDuration")]
        //public async Task<ActionResult<CharacterDTO>> Get(int id) // Having Task<IActionResult> defines a contract that represents the result of an action method which will not display scheme or data
        //{
        //    // var character = _characterService.GetCharacters().Find(element => element.Id == id); //find character we want 
        //    var character = await this.context.characters.FindAsync(id);
        //    if (character == null)
        //        return BadRequest("The character you are looking for does not exist!");
        //    return Ok(character);
        //}

        //[HttpPost]
        //public async Task<ActionResult<List<CharacterDTO>>> AddCharacter(CharacterDTO request)
        //{
        //    this.context.characters.Add(request);
        //    //var character = _characterService.GetCharacters().Find(element => element.Id == request.Id);
        //        //var character = this.context.characters.Add(request);
        //    await this.context.SaveChangesAsync();
        //        //if (character != null)
        //            //return BadRequest("This unique ID already exists, Please use different ID");
        //    //return Ok(_characterService.PostSuperHero(request));
        //    return Ok(await this.context.characters.ToListAsync());
        //}


        //[HttpPut]
        //public async Task<ActionResult<List<CharacterDTO>>> UpdateCharacter(CharacterDTO request)
        //{
        //    //var character = _characterService.GetCharacters().Find(element => element.Id == request.Id); //find the character we want
        //    var dbCharacter = await this.context.characters.FindAsync(request.Id);
        //    if (dbCharacter == null)
        //        return BadRequest("The character you are looking for does not exist!");

        //    dbCharacter.Name = request.Name;
        //    dbCharacter.FirstName = request.FirstName;
        //    dbCharacter.LastName = request.LastName;
        //    dbCharacter.Age = request.Age;

        //    await this.context.SaveChangesAsync();

        //   // return Ok(_characterService.UpdateSuperHero(request));
        //   return Ok(await this.context.characters.ToListAsync());

        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<CharacterDTO>>> DeleteCharacter(int id)
        //{
        //   // var character = _characterService.GetCharacters().Find(element => element.Id == id); //find the character we want
        //   var dbCharacter = await this.context.characters.FindAsync(id); 
        //    if (dbCharacter == null)
        //        return BadRequest("The character you are looking for does not exist!");

        //    //_characterService.DeleteCharacter(id);
        //    this.context.characters.Remove(dbCharacter);
        //    await this.context.SaveChangesAsync();

        //    return Ok(await this.context.characters.ToListAsync());

        //}

        //[HttpGet]
        //[Route("/pokemon/{pokemonName}")]
        //[ProducesResponseType(typeof(string), StatusCodes.Status200OK)] //When status code 200, it product response type of string
        //public async Task<IActionResult> PokemonFight([Required] string pokemonName)
        //{
        //    return new OkObjectResult(await _characterService.PokemonBattle(pokemonName));
        //}

    }
}
