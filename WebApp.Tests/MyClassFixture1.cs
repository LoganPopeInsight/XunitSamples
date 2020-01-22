using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Tests
{
    public class MyClassFixture : IDisposable
    {
        public Guid FixtureId { get; set; }
        public MyClassFixture()
        {
            FixtureId = Guid.NewGuid();
        }

        public void Dispose()
        {
            //Cleanup 
        }
    }
}
