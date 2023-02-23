using System;
using MediatR;
using Respawn;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Restaurant.Infrastructure.Identity;
using Restaurant.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Respawn.Graph;
using FluentAssertions;
using Restaurant.Application.TestEntities.Commands.CreateTestEntity;
using Restaurant.Domain.Entites;
using FluentValidation;

namespace Restaurant.Application.IntegrationTests.TestEntity.Commands
{
    using static Testing;

    public class CreateTestEntityTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateTestEntityCommand();

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldRequireMoreThan0InSeatsCountValue()
        {
            var command = new CreateTestEntityCommand() { SeatsCount = 0};

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTestEntity()
        {
            var userId = await RunAsDefaultUserAsync();

            var itemId = await SendAsync(new CreateTestEntityCommand
            {
                SeatsCount = 4
            });

            var item = await FindAsync<Restaurant.Domain.Entites.TestEntity>(itemId);

            item.Should().NotBeNull();
            item!.SeatsCount.Should().Be(4);
            item.Reserved.Should().Be(false);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}

