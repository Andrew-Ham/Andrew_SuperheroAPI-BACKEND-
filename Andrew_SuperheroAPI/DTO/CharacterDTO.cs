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

        public string Location { get; set; }
        public int Strength { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }

        public string BirthYear
        {
            get
            {
                return DateTime.Now.AddYears((Age * -1)).ToString("yyyy");
            }
        }

    }
}
