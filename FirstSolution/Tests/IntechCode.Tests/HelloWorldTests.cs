using FluentAssertions;
using Xunit;

namespace IntechCode.Tests
{
    [NUnit.Framework.TestFixture]
    public class HelloWorldTests
    {
        [NUnit.Framework.Test]
        [Fact]
        public void HelloWorld_says_hello_in_hexadecimal()
        {
            HelloWorld.SayHelloWorld(10).Should().Be("Count is A");
            (4 + 5).Should().Be(9);
        }
    }
}
