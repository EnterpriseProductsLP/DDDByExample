using System;
using FluentAssertions;
using NUnit.Framework;

namespace Erp.SupportContext.UnitTests
{
    [TestFixture]
    public class CustomerVoTests
    {
        [Test]
        public void CanCreateDefaultInstance()
        {
            CustomerVo customerVo = null;
            Action action = () => customerVo = new CustomerVo();
            action.ShouldNotThrow();
            customerVo.Should().NotBeNull();
        }
    }
}
