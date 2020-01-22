using System;
using WebApp.Models;
using Xunit;
using Xunit.Abstractions;

namespace WebApp.Tests
{
    public class PilotShould: IClassFixture<MyClassFixture>, IDisposable
    {
        //Custom output using Xunit.Abstractions
        private ITestOutputHelper _output { get; set; }
        public PilotShould(ITestOutputHelper output, MyClassFixture myClassFixture)
        {
            _output = output;
            _output.WriteLine("Creating Pilot");

            _myClassFixture = myClassFixture;

            _p = new Pilot(firstName: "John", lastName: "Doe");
        }

        private readonly Pilot _p;

        private readonly MyClassFixture _myClassFixture;

        public void Dispose()
        {
            _output.WriteLine("Disposing pilot.");
            //_p.Dispose()
        }


        //String examples
        [Fact]
        public void CalculateFullName()
        {
            //Arrange
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");

            _output.WriteLine("This is how we write custom output in our tests.");

            //Assert
            Assert.Equal("John Doe", p.FullName);
        }

        [Fact]
        public void HaveFullNameStartsWithFirstName()
        {
            //duplcate arrange code. Lets reduce this by adding it to the constructor. 
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");

            Assert.StartsWith("John", p.FullName);
        }

        [Fact]
        [Trait("Category", "Class Fixture")]
        public void HaveFullNameEndsWithLastName()
        {
            //Class fixture can be used between tests. 
            _output.WriteLine($"Fixture Id: {_myClassFixture.FixtureId}");
            Assert.EndsWith("Doe", _p.FullName);
        }

        [Fact]
        [Trait("Category", "Class Fixture")]
        public void CalculateFullName_IgnoreCase()
        {
            _output.WriteLine($"Fixture Id: {_myClassFixture.FixtureId}");
            Assert.Equal("John Doe", _p.FullName, ignoreCase: true);
        }

        [Fact(Skip ="This test is not needed at this time.")] //Skips the test with a message. 
        public void CalculateFullName_Substring()
        {
            Assert.Contains("hn Do", _p.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", p.FullName);
        }

        //numeric
        [Fact]
        [Trait("Category", "Numeric")]
        public void NewPilotStartsWithDefaultVacationDays()
        {
            //Arrange
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");

            //Act
            p.NewPilotSetUp(p);

            //Assert
            Assert.Equal(10, p.VacationDays);
        }

        [Fact]
        [Trait("Category", "Numeric")]
        public void NewPilotStartsWithDefaultVacationDays_NotEqual()
        {
            //Arrange
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");

            //Act
            p.NewPilotSetUp(p);

            //Assert
            Assert.NotEqual(0, p.VacationDays);
        }

        [Fact]
        [Trait("Category", "Numeric")]
        public void IncreaseVacationDaysAfterPromotion()
        {
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");

            p.NewPilotSetUp(p);
            p.PilotPromoted(p);

            //Assert.True(p.VacationDays > 0 && p.VacationDays <= 15); 
            //Above will work but InRange has better error message for this type of evaluation. 
            Assert.InRange(p.VacationDays, 1, 15);
        }

        //Null Values
        [Fact]
        [Trait("Category","Null Values")]
        public void NotHaveNicknameByDefault()
        {
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");

            p.NewPilotSetUp(p);

            Assert.Null(p.Nickname);
        }

        //Data Driven
        [Theory]
        [InlineData(1, 9)]
        [InlineData(2, 8)]
        [InlineData(3, 7)]
        public void PilotPenalized(int penaltyDays, int expectedVacationDays)
        {
            Pilot p = new Pilot(firstName: "John", lastName: "Doe");
            p.NewPilotSetUp(p);
            p.PilotPenalized(p, penaltyDays);

            Assert.Equal(expectedVacationDays, p.VacationDays);

        }




        




    }
}
