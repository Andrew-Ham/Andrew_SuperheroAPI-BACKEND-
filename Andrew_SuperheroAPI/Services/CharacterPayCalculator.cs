using Andrew_SuperheroAPI.Contracts;

namespace Andrew_SuperheroAPI.Services
{
    public class CharacterPayCalculator : ICharacterPayCalculator
    {
        public decimal CalculateCharacterSalary(decimal hoursWorkedPerWeek, decimal hourlyRate)
        {
            if (hoursWorkedPerWeek != null && hourlyRate != null)
            {
                return hoursWorkedPerWeek * hourlyRate * 52;
            }
            return 0;
        }

        public decimal CalculateTotalEarnings(int age, decimal hoursWorkedPerWeek, decimal hourlyRate)
        {
            if (hourlyRate != null && hoursWorkedPerWeek != null && age != null)
            {
                return age * CalculateCharacterSalary(hoursWorkedPerWeek, hourlyRate);
            }
            return 0;
        }

        public decimal CalculateStrengthToPayRatio(int strength, decimal hourlyRate)
        {
            if (hourlyRate == null || hourlyRate == 0 || strength == null)
            {
                return 0;
            } 
            return strength / hourlyRate;
        }
    }
}
