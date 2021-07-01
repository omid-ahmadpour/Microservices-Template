using Slice.Framework.Core.Entities;
using System;

namespace Slice.Services.Identity.Core.Entities
{
    public class Role : IEntity
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Role(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
