using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andrew_SuperheroAPI
{
    public class CharacterDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }    
        public int Age { get; set; }

        public DateTime BirthYear
        {
            get
            {
                return DateTime.Now.AddYears((Age * -1));
            }
        }

    }
}
