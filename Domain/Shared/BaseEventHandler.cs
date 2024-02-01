using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Shared;

public class BaseEventHandler<TEvent>(ILogger<TEvent> logger)
    where TEvent : INotification
{
    public Task Handle(TEvent notification, CancellationToken token)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}