namespace Team13SmartGarage.Data.Models
{
    public interface IEntity { }
    public interface IEntity<TPrimaryKey> : IEntity
    {
        TPrimaryKey Id { get; set; }
    }
}