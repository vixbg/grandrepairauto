namespace GrandRepairAuto.Services.Contracts
{
    public interface IDTO { }

    public interface IDTO<TPrimaryKey> : IDTO
    {
        TPrimaryKey Id { get; set; }
    }
}