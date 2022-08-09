using Character.Service.Contracts;

namespace Character.Service
{
    public class CharacterLogic : ICharactersLogic
    {
        public List<string> GetMarvelHeroes()
        {
            return new List<string>() { "Ironman", "BatMan", "SpiderMan" };
        }
    }
}
