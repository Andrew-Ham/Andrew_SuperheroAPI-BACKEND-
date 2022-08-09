using Newtonsoft.Json;

namespace Andrew_SuperheroAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public List<Abilities> Abilities { get; set; }
    }

    public class Abilities
    {
        public bool Is_Hidden { get; set; }
        public int Slot { get; set; }
        public Ability Ability { get; set; }    
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }

}
