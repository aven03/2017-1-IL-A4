using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntechCode.Tests
{
    public class MyDictionaryTests
    {
        [Fact]
        public void modulo_in_csharp()
        {
            {
                int i = -3;
                int j = i % 7;
                j.Should().Be(-3);
            }
            {
                int i = -10;
                int j = i % 7;
                j.Should().Be(-3);
            }
        }
    }
}
