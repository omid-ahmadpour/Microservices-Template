using System.Collections.Generic;

namespace Slice.Services.Identity.Core.Entities
{
    public class AggregateRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> Events => _events;


    }
}
