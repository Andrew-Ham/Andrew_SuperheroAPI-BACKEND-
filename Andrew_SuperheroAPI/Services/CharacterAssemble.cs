using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Models;

namespace Andrew_SuperheroAPI.Service
{
    public class CharacterAssemble : ICharacterAssemble
    {
        private IPokemon _pokemon;
        private ICharacterRepository _characterRepository;
        private ICharacterPayCalculator _characterPayCalculator;

        public CharacterAssemble(ICharacterRepository characterRepository, ICharacterPayCalculator characterPayCalculator, IPokemon pokemon)
        {
            _characterRepository = characterRepository;
            _characterPayCalculator = characterPayCalculator;
            _pokemon = pokemon;
        }

        public async Task<IList<Character>> GetCharacters()
        {
            var result = new List<Character>();
            var characterDTOList = await _characterRepository.GetCharactersFromContext();
            foreach (var element in characterDTOList)
            {
                var character = new Character() 
                { 
                    Age = element.Age, 
                    Name = $"{element.Name}",
                    FirstName = element.FirstName,
                    LastName = element.LastName,
                    BirthYear = element.BirthYear, 
                    Location = element.Location, 
                    Strength = element.Strength,
                    HoursWorked = element.HoursWorked,
                    HourlyRate = element.HourlyRate
                };
                result.Add(character);
            }
            return result;
        }

        public async Task<Character> GetHighestSalaryChracter()
        {
            var highestPaid = default(decimal);
            var characterName = default(string);
            var characterDTOList = await _characterRepository.GetCharactersFromContext();
            foreach ( var element in characterDTOList)
            {
                var characterPay = _characterPayCalculator.CalculateCharacterSalary(element.HoursWorked, element.HourlyRate);
                if (characterPay > highestPaid)
                {
                    highestPaid = characterPay;
                    characterName = element.Name; 
                }
            }
            var characterDto = characterDTOList.FirstOrDefault(x=>x.Name == characterName);
            return new Character() {
                Age = characterDto.Age,
                Name = characterDto.Name,
                HourlyRate = characterDto.HourlyRate,
                HoursWorked = characterDto.HoursWorked,
                BirthYear = characterDto.BirthYear,
                Strength = characterDto.Strength,
                Location = characterDto.Location
            };
        }

        public async Task<IList<CharacterDTO>> PostCharacter(CharacterDTO character)
        {
            
            return await _characterRepository.PostCharacter(character); 
        }

        public async Task<CharacterDTO> GetCharacterByName(string name)
        {
            return await _characterRepository.GetCharacterByNameFromContext(name); //find the character we want

        } //find the character we want

        public async Task<IList<CharacterDTO>> DeleteCharacter(CharacterDTO character)
        {
            return await _characterRepository.DeleteCharacter(character);
        }

        public async Task<IList<CharacterDTO>> UpdateCharacter(Character character)
        {
            var characterDTO = new CharacterDTO()
            {
                Age = character.Age,
                Name = character.Name,
                FirstName = character.FirstName,
                LastName = character.LastName,
                HourlyRate = character.HourlyRate,
                HoursWorked = character.HoursWorked,
                Location = character.Location,
                Strength = character.Strength
            };
            return await _characterRepository.UpdateCharacter(characterDTO);
        }

        public async Task<IList<CharacterPay>> GetCharacterPays()
        {
            var result =  new List<CharacterPay>();
            var characters = await _characterRepository.GetCharactersFromContext();
            foreach (var character in characters)
            {
                var payObject = new PayObject()
                {
                    Salary = _characterPayCalculator.CalculateCharacterSalary(character.HoursWorked, character.HourlyRate),
                    StrengthPayRatio = _characterPayCalculator.CalculateStrengthToPayRatio(character.Strength, character.HourlyRate),
                    TotalEarnings = _characterPayCalculator.CalculateTotalEarnings(character.Age, character.HoursWorked, character.HourlyRate)
                };
                result.Add(new CharacterPay()
                {
                    CharacterPayObject = new Dictionary<string, PayObject>
                    {
                        { character.Name, payObject }
                    }
                });
            }
            return result;
        }

        public async Task<string> PokemonBattle(string pokemonName)
        {
            var superHeroes = await _characterRepository.GetCharactersFromContext();
            var randomHeroesToSelect = new Random().Next(1, superHeroes.Count);
            var heroToFightAgainstPokemon = superHeroes[randomHeroesToSelect];

            var pokemon = await _pokemon.GetPokemon(pokemonName); //await for api response for data
            if (pokemon == null)
            {
                return $"No Pokemon Found!, {heroToFightAgainstPokemon.Name} has won!";
            }
            else
            {
                var rangeOfMoves = pokemon.Abilities.Count;
                var randomNum = new Random().Next(0, rangeOfMoves);
                return $"Wild {pokemonName} used {pokemon.Abilities[randomNum].Ability.Name} move! {heroToFightAgainstPokemon.Name} took 5 damage from it";
            }
        }
    }
}
