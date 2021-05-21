using System;
using System.Linq;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Data.Filters
{
    public class VehicleFilter : IFilter<Vehicle>
    {
        public string Owner { get; set; }

        public IQueryable<Vehicle> Apply(IQueryable<Vehicle> entities)
        {
            if (!string.IsNullOrEmpty(this.Owner))
            {
                //TODO: Create USER Model
                //entities = entities
                //.Where(e => e.Owner.FirstName.Contains(this.Owner, StringComparison.OrdinalIgnoreCase) ||
                //e => e.Owner.LastName.Contains(this.Owner, StringComparison.OrdinalIgnoreCase) ||
                //e => e.Owner.Email.Contains(this.Owner, StringComparison.OrdinalIgnoreCase));
                return entities; //Remove when done
            }

            return entities;
        }
    }
}