using System;
using System.Linq;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Data.Filters
{
    public class ServiceFilter : IFilter<Service>
    {
        public string Name { get; set; }

        public double? FixedPrice { get; set; }

        public IQueryable<Service> Apply(IQueryable<Service> entities)
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                entities = entities
                    .Where(s => s.Name
                    .Contains(this.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (this.FixedPrice > 0)
            {
                entities = entities.Where(s => s.FixedPrice == this.FixedPrice);
            }

            return entities;
        }
    }
}
