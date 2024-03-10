using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using TaskManagerApp.Application;
using TaskManagerApp.Application.Tasks.Commands.AddDocument;
using TaskManagerApp.Application.Tasks.Commands.Create;
using TaskManagerApp.Test.Infrastructure;

namespace TaskManagerApp.Test
{
    public class TaskTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task CanAddTasks()
        {
            var expectedCount = 3;

            using (var context = new DbContextHelper().Context)
            {
                var services = new ServiceCollection();
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyTag).Assembly));

                var provider = services.BuildServiceProvider();


                var handler = new CreateTaskCommandHandler(context);
                await handler.Handle(new CreateTaskCommand("testTask"), new CancellationToken());
                await handler.Handle(new CreateTaskCommand("testTask2"), new CancellationToken());
                await handler.Handle(new CreateTaskCommand("testTask3"), new CancellationToken());

                var tasks = await context.Tasks.ToListAsync();
                Assert.That(tasks.Count(), Is.EqualTo(expectedCount));
            }
        }
    }
}