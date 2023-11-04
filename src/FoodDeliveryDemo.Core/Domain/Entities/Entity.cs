using System;

namespace FoodDeliveryDemo.Domain.Entities
{
    public abstract class Entity : Entity<Guid>, IEntity
    {
    }

    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
