using System.ComponentModel.DataAnnotations;

namespace Team13SmartGarage.Data.Models
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get;  set;  }
    }
}