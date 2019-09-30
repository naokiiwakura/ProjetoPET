using System;

namespace Domain.Model
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedData { get; set; }
    }
}
