using System;

namespace FoodDeliveryDemo.Domain.Entities
{
    /// <summary>
    /// Estructura base para la definición de entidades. Especifica el tipo de clave
    /// primaria que utilizará.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Define el tipo de dato de la clave primaria</typeparam>
    public abstract class Entity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// Clase especializada con el tipo de clave primaria Guid por defecto.
    /// </summary>
    public abstract class Entity : Entity<Guid>
    {
    }
}
