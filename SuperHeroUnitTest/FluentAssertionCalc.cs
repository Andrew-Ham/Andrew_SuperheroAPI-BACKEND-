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
    public class FluentAssertionCalc
    {
        private ICharacterPayCalculator _characterPayCalculator;

        [SetUp]
        public void SetUp()
        {
            _characterPayCalculator = new CharacterPayCalculator();
        }

        [Test]
        public void Verify_Salary_Earning()
        {
            var result = _characterPayCalculator.CalculateCharacterSalary(40, 20);
            var expected = 40 * 20 * 52;
            var outcome = result.Should().Be(expected);
        }

        [Test]
        public void Verify_Salary_Earning_Hours_Is_Null()
        {
            var result = _characterPayCalculator.CalculateCharacterSalary(0, 30);
            var expected = 0;
            var outcome = result.Should().Be(expected);
        }
        
        [Test]
        public void Verify_Total_Earnings()
        {
            var result = _characterPayCalculator.CalculateTotalEarnings(50, 40, 30);
            var expected = 50 * 40 * 30 * 52;
            var outcome = result.Should().Be(expected);
        }

        [Test]
        public void Verify_Total_Earnings_Is_Null()
        {
            var result = _characterPayCalculator.CalculateTotalEarnings(50, 0, 0);
            var expected = 0;
            var outcome = result.Should().Be(expected);
        }

        [Test]
        public void Verify_Strength_Pay_Ratio()
        {
            var result = _characterPayCalculator.CalculateStrengthToPayRatio(2000, 50);
            var expected = 2000 / 50;
            var outcome = result.Should().Be(expected);
        }

        [Test]
        public void Verify_Strength_Pay_Ratio_Is_Null()
        {
            var result = _characterPayCalculator.CalculateStrengthToPayRatio(1000, 0);
            var expected = 0;
            var outcome = result.Should().Be(expected);
        }
    } 

}
