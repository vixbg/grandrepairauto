namespace Team13SmartGarage.Services.Models
{
    public class DTO<TPrimaryKey> : IDTO<TPrimaryKey>
    { 
        public TPrimaryKey Id { get;  set; }
    }
}