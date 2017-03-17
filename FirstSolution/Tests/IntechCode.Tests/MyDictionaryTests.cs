using FluentAssertions;
using IntechCode.IntechCollection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntechCode.Tests
{
    public class MyDictionaryTests
    {
        [Fact]
        public void modulo_in_csharp_propagates_negative_value()
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

        [Fact]
        public void adding_existing_key_throws_an_exception()
        {
            var d = new MyDictionary<int, string>();
            d.Add(1, "One");
            d.Add(2, "Two");
            d.Count.Should().Be(2);
            Action a1 = () => d.Add(1, "Duplicate One");
            Action a2 = () => d.Add(2, "Duplicate Two");
            a1.ShouldThrow<Exception>();
            a2.ShouldThrow<Exception>();
        }

        [Fact]
        public void iterating_on_a_dictionary_gives_the_KeyValuePair_items()
        {
            var d = new MyDictionary<int, string>();
            d.Add(1, "One");
            d.Add(2, "Two");
            d.Add(42, "Fourty two");
            var foundKeys = new MyList<int>();
            int turn = 0;
            foreach (var kv in d)
            {
                foundKeys.IndexOf(kv.Key).Should().Be(-1);
                foundKeys.Add(kv.Key);
                ++turn;
            }
            turn.Should().Be(3);
        }

        [Theory]
        [InlineData(56)]
        [InlineData(979)]
        [InlineData(-143)]
        [InlineData(98)]
        [InlineData(10928)]
        [InlineData(365)]
        [InlineData(0)] // No seed!
        public void ContainsKey_in_a_dictionary( int seed )
        {
            // Arrange
            var r = seed == 0 ? new Random() : new Random( seed );
            MyList<int> keys = CreateRandomListOfUniqueNumber(r);
            var sut = new MyDictionary<int, string>();
            // Act: adds unique numbers to the sut.
            foreach (var num in keys)
            {
                sut.Add(num, num.ToString());
            }
            // Assert
            // Added keys must all return true.
            foreach (var num in keys)
            {
                sut.ContainsKey(num).Should().BeTrue();
            }
            // Check that ContainsKey can also return false!
            for( var i = 0; i < 300; i++ )
            {
                var n = r.Next();
                sut.ContainsKey(n).Should().Be(keys.IndexOf(n) >= 0);
            }
        }

        static MyList<int> CreateRandomListOfUniqueNumber(Random r, int maxLength = 200)
        {
            var keys = new MyList<int>();
            for (int i = 0; i < maxLength; ++i)
            {
                var rand = r.Next();
                if (keys.IndexOf(rand) < 0) keys.Add(rand);
            }

            return keys;
        }
    }
}