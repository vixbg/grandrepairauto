using System;

namespace Team13SmartGarage.Data.Models
{
    public interface ISoftDeletable
    {
        DateTime? IsDeleted { get; set; }
    }
}