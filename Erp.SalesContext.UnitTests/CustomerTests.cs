using System;
using FluentAssertions;
using NUnit.Framework;

namespace Erp.SalesContext.UnitTests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void CanCreateDefaultInstance()
        {
            Customer customer = null;
            Action action = () => customer = new Customer();
            action.ShouldNotThrow();
            customer.Should().NotBeNull();
        }
    }
}