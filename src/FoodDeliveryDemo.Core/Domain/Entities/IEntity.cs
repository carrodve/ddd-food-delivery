using System;

namespace FoodDeliveryDemo.Domain.Entities
{
    public interface IEntity : IEntity<Guid>
    {
    }

    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
