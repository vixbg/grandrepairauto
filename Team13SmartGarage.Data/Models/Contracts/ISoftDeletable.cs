using System;

namespace Team13SmartGarage.Data.Models.Contracts
{
    public interface ISoftDeletable
    {
        DateTime? DeletedOn { get; set; }
    }
}