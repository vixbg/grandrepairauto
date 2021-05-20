using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Data.Filters
{
    public class OrderFilter : IFilter<Order>
    {
        public string Vehicle { get; set; }

        public DateTime? Date { get; set; }
        public IQueryable<Order> Apply(IQueryable<Order> entities)
        {
            if (!string.IsNullOrEmpty(this.Vehicle))
            {
                entities = entities.Where(o =>
                    o.Vehicle.RegPlate.Contains(this.Vehicle, StringComparison.OrdinalIgnoreCase));
            }

            if (this.Date.HasValue)
            {
                // entities = entities.Where( o => o.)
            }

            return entities;
        }
    }
}
