using System.Collections.Generic;

namespace Slice.Framework.Shared.Core.Entities
{
    public class AggregateRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> Events => _events;

        public AggregateId Id { get; protected set; }

        public int Version { get; protected set; }

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();
    }
}
