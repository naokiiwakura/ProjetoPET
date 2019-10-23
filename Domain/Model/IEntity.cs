using System;

namespace Domain.Model
{
        public interface IEntity
        {
            int Id { get; set; }
            DateTime CreatedDate { get; set; }
            DateTime? UpdatedData { get; set; }
        }
    }