using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
 
        public interface IEntity
        {
            int Id { get; set; }
            DateTime CreatedDate { get; set; }
            DateTime? UpdatedData { get; set; }
        }
    }


