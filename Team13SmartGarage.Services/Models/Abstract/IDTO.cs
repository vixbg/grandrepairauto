namespace Team13SmartGarage.Services.Models
{
    public interface IDTO { }

    public interface IDTO<TPrimaryKey> : IDTO
    {
        TPrimaryKey Id { get; set; }
    }
}