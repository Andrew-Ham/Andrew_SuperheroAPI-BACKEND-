using Andrew_SuperheroAPI;
using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Models;
using Andrew_SuperheroAPI.Service;
using Moq;
using NUnit.Framework;
namespace SuperHeroUnitTest
{
    public class Test
    {

        [Test]
        public void Should_Return_One_Element()
        {
            var mockPokemon = new Mock<IPokemon>();
            var mockSuperHero = new Mock<ISuperHero>();

            var mockedObject = new List<Character>()
            {
                new Character() { Name = "Andrew", Id = 100}
            };

            mockSuperHero.Setup(x => x.GetSuperHeroes()).Returns(mockedObject);

            var service = new CharacterAssemble(mockPokemon.Object, mockSuperHero.Object);
            Assert.IsTrue(service.GetCharacters().Count == 1);
        }

        [Test]
        public void Should_Add_BatMan()
        {
            var mockPokemon = new Mock<IPokemon>();
            var mockSuperHero = new Mock<ISuperHero>();

            var mockedObject = new List<Character>()
            {
                new Character() { Name = "BatMan", Id = 100}
            };

            mockSuperHero.Setup(x => x.GetSuperHeroes()).Returns(mockedObject);

            var service = new CharacterAssemble(mockPokemon.Object, mockSuperHero.Object);
            Assert.IsTrue(service.GetCharacters()[0].Name == "BatMan");
        }
    }
}


