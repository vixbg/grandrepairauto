namespace GrandRepairAuto.Data.Models.Contracts
{
    public interface IEntity { }
    public interface IEntity<TPrimaryKey> : IEntity
    {
        TPrimaryKey Id { get; set; }
    }
}