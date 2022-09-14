using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Andrew_SuperheroAPI;
using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Models;
using Andrew_SuperheroAPI.Services;
using Moq;
using FluentAssertions;
using Andrew_SuperheroAPI.Service;

namespace SuperHeroUnitTest
{
    public class SuperHeroUnitTest
    {
        private ICharacterAssemble _characterAssemble;
        private ICharacterPayCalculator _characterPayCalculator;
        //yes

        private Mock<ICharacterRepository> _characterRepositryMock;
        //private Mock<ICharacterPayCalculator> _characterPayCalculator;
        private Mock<IPokemon> _pokemon;
        [SetUp]
        public void SetUp()
        {
            _characterRepositryMock = new Mock<ICharacterRepository>();
            _characterPayCalculator = new CharacterPayCalculator();
            _pokemon = new Mock<IPokemon>();

            _characterRepositryMock.Setup(x => x.GetCharactersFromContext()).ReturnsAsync(SetUpMockData());
            _characterAssemble = new CharacterAssemble(_characterRepositryMock.Object, _characterPayCalculator, _pokemon.Object);
        }

        [Test]
        public void Veify_Highest_Paid_User()
        {
            var mockedCharacters = _characterAssemble.GetHighestSalaryChracter().Result;
            var mockedData = SetUpMockData();
            var expected = new Character()
            {
                Age = mockedData[1].Age,
                Name = mockedData[1].Name,
                FirstName = mockedData[1].FirstName,
                LastName = mockedData[1].LastName,
                HourlyRate = mockedData[1].HourlyRate,
                HoursWorked = mockedData[1].HoursWorked,
                Location = mockedData[1].Location,
                Strength = mockedData[1].Strength,
                BirthYear = mockedData[1].BirthYear
            };

            var result = mockedCharacters.Should().BeEquivalentTo(expected);
        }

        private List<CharacterDTO> SetUpMockData()
        {
            var result = new List<CharacterDTO>();
            result.Add(new CharacterDTO()
            {
                Age = 13,
                Name = "Test_1",
                HourlyRate = 15,
                HoursWorked = 5,
                Location = "Auckland",
                Strength = 300
            });
            result.Add(new CharacterDTO()
            {
                Age = 13,
                Name = "Test_2",
                HourlyRate = 30,
                HoursWorked = 55,
                Location = "Auckland",
                Strength = 300
            });

            result.Add(new CharacterDTO()
            {
                Age = 13,
                Name = "Test_3",
                HourlyRate = 15,
                HoursWorked = 25,
                Location = "Auckland",
                Strength = 300
            });

            return result;
        }
    }
}
