using System.ComponentModel.DataAnnotations;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Data.Models.Abstract
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get;  set;  }
    }
}