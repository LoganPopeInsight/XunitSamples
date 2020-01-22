using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebApp.Tests
{
    [CollectionDefinition("Application Collection")]
    public class MyCollectionFixture : ICollectionFixture<MyClassFixture> { }
    
}
