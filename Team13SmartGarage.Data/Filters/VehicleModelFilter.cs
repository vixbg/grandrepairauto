﻿using System;
using System.Linq;
using Team13SmartGarage.Data.Filters.Contracts;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Data.Filters
{
    public class VehicleModelFilter : IFilter<VehicleModel>
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public IQueryable<VehicleModel> Apply(IQueryable<VehicleModel> entities)
        {
            if (!string.IsNullOrEmpty(this.Make))
            {

                entities = entities
                    .Where(e => e.Manufacturer.Name.Contains(this.Make, StringComparison.OrdinalIgnoreCase));
                
            }

            if (!string.IsNullOrEmpty(this.Model))
            {

                entities = entities
                    .Where(e => e.Name.Contains(this.Model, StringComparison.OrdinalIgnoreCase));
            }


            return entities;
        }
    }
}