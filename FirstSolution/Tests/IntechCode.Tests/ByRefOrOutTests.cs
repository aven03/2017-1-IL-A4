using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntechCode.Tests
{
    public class ByRefOrOutTests
    {
        [Fact]
        public void byref_demo()
        {
            int i = 0;
            IChangeMyParam(ref i);
            i.Should().Be(9786);
            IInitializeMyParam(out i);
            int j;
            IInitializeMyParam(out j)
;        }

        static void IChangeMyParam(ref int param) => param += 9786;
        static void IInitializeMyParam(out int param) => param = 123;
    }
}
