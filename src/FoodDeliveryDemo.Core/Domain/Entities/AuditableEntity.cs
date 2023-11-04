using System;

namespace FoodDeliveryDemo.Domain.Entities
{
    public abstract class AuditableEntity<TPrimaryKey> : Entity<TPrimaryKey>
    {
        public DateTime CreationTime { get; set; }

        public DateTime? ModificationTime { get; set; }

        protected AuditableEntity()
        {
            CreationTime = DateTime.Now;
        }
    }

    public abstract class AuditableEntity : AuditableEntity<Guid>
    {
    }
}
