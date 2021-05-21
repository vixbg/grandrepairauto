using System;

namespace GrandRepairAuto.Data.Models.Contracts
{
    public interface ISoftDeletable
    {
        DateTime? DeletedOn { get; set; }
    }
}