using Andrew_SuperheroAPI.Models;

namespace Andrew_SuperheroAPI.Contracts
{
    public interface IPokemon
    {
        Task<Pokemon> GetPokemon(string pokemonName);
    }
}
