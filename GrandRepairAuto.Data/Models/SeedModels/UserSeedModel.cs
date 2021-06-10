﻿using System.Collections.Generic;

namespace GrandRepairAuto.Data.Models.SeedModels
{
    public class UserSeedModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public List<string> Roles { get; set; }
    }
}
