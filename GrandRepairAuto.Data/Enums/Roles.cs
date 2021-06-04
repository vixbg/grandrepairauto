﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GrandRepairAuto.Data.Enums
{
    public static class Roles
    {
        public const string Admin = "Administrator";
        public const string Employee = "Employee";
        public const string Customer = "Customer";

        public const string AdminsAndEmployees = "Administrator, Employee";

        public const string All = "Administrator, Employee, Customer";

        public static readonly string[] AllRoles = new[] { Admin, Employee, Customer };
    }
}
