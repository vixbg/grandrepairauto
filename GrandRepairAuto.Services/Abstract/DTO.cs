using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Abstract
{
    public class DTO<TPrimaryKey> : IDTO<TPrimaryKey>
    { 
        public TPrimaryKey Id { get;  set; }
    }
}