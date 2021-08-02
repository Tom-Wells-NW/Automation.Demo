using FluentAssertions;
using System;
using Xunit;

namespace Automation.Demo.Client.UnitTests
{
    public class DummyClassTests
    {
        [Fact]
        public void Can_validate_name()
        {
            var dummyClass = new DummyClass();

            var isValidName = dummyClass.IsValidName("test name");

            isValidName.Should().Be(true);
        }
    }
}
