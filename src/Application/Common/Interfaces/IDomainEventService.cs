using Movies.Domain.Common;
using System.Threading.Tasks;

namespace Movies.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
