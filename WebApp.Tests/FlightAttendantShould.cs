using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace WebApp.Tests
{
    [Collection("Application Collection")]
    public class FlightAttendantShould
    {

        private readonly MyClassFixture _myClassFixture;
        private readonly ITestOutputHelper _output;


        public FlightAttendantShould(MyClassFixture myClassFixture, ITestOutputHelper output)
        {
            _myClassFixture = myClassFixture;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Collection Fixture")]
        public void GenericTest()
        {
            _output.WriteLine($"Fixture Id: {_myClassFixture.FixtureId}");
            
        }

    }
}
