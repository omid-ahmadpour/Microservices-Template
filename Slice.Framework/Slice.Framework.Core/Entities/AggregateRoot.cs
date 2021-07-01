using System.Collections.Generic;

namespace Slice.Framework.Core.Entities
{
    public class AggregateRoot
    {
        private readonly List<IDomainEvent> _events = new();

        public IEnumerable<IDomainEvent> Events => _events;

        public int Version { get; protected set; }

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();
    }
}
