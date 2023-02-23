using System;
using Restaurant.Application.IntegrationTests.TestEntity.Commands;
using NUnit.Framework;

namespace Restaurant.Application.IntegrationTests
{
    using static Testing;

    [TestFixture]
    public abstract class BaseTestFixture
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}

