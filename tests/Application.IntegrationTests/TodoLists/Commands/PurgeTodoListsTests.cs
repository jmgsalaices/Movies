using Movies.Application.Common.Exceptions;
using Movies.Application.Common.Security;
using Movies.Application.TodoLists.Commands.CreateTodoList;
using Movies.Application.TodoLists.Commands.PurgeTodoLists;
using Movies.Application.TodoLists.Queries.ExportTodos;
using Movies.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Movies.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class PurgeTodoListsTests : TestBase
    {
        [Test]
        public void ShouldDenyAnonymousUser()
        {
            var command = new PurgeTodoListsCommand();

            command.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<UnauthorizedAccessException>();
        }

        [Test]
        public async Task ShouldDenyNonAdministrator()
        {
            await RunAsDefaultUserAsync();

            var command = new PurgeTodoListsCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ForbiddenAccessException>();
        }

        [Test]
        public async Task ShouldAllowAdministrator()
        {
            await RunAsAdministratorAsync();

            var command = new PurgeTodoListsCommand();

            FluentActions.Invoking(() => SendAsync(command))
                .Should().NotThrow<ForbiddenAccessException>();
        }

        [Test]
        public async Task ShouldDeleteAllLists()
        {
            await RunAsAdministratorAsync();

            await SendAsync(new CreateTodoListCommand
            {
                Title = "New List #1"
            });

            await SendAsync(new CreateTodoListCommand
            {
                Title = "New List #2"
            });

            await SendAsync(new CreateTodoListCommand
            {
                Title = "New List #3"
            });

            await SendAsync(new PurgeTodoListsCommand());

            var count = await CountAsync<TodoList>();

            count.Should().Be(0);
        }
    }
}
