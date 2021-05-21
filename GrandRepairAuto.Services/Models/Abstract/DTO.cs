using GrandRepairAuto.Services.Models.Contracts;

namespace GrandRepairAuto.Services.Models.Abstract
{
    public class DTO<TPrimaryKey> : IDTO<TPrimaryKey>
    { 
        public TPrimaryKey Id { get;  set; }
    }
}