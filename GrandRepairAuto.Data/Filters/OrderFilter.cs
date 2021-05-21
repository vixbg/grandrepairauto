using System;
using System.Linq;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Data.Filters
{
    public class OrderFilter : IFilter<Order>
    {
        public string Vehicle { get; set; }

        public DateTime? Date { get; set; }
        public IQueryable<Order> Apply(IQueryable<Order> entities)
        {
            if (!string.IsNullOrEmpty(this.Vehicle))
            {
                entities = entities
                    .Where(o => o.Vehicle.RegPlate
                    .Contains(this.Vehicle, StringComparison.OrdinalIgnoreCase));
            }

            if (this.Date.HasValue)
            {
                entities = entities.Where(o => o.Date.Equals(this.Date));
            }

            return entities;
        }
    }
}
