using System.ComponentModel.DataAnnotations;
using Team13SmartGarage.Data.Models.Contracts;

namespace Team13SmartGarage.Data.Models.Abstract
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get;  set;  }
    }
}