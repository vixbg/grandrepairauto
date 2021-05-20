using Team13SmartGarage.Services.Models.Contracts;

namespace Team13SmartGarage.Services.Models.Abstract
{
    public class DTO<TPrimaryKey> : IDTO<TPrimaryKey>
    { 
        public TPrimaryKey Id { get;  set; }
    }
}