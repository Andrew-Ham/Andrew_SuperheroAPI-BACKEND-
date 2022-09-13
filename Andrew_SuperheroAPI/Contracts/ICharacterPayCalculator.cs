namespace Andrew_SuperheroAPI.Contracts
{
    public interface ICharacterPayCalculator
    {
        decimal CalculateCharacterSalary(decimal hoursWorkedPerWeek, decimal hourlyRate);
        decimal CalculateTotalEarnings(int age, decimal hoursWorkedPerWeek, decimal hourlyRate);
        decimal CalculateStrengthToPayRatio(int strength, decimal hourlyRate);
    }
}
