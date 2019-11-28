using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.DTO.Identity
{
    public class AppUser :  IdentityUser<int> // PK type is int
    {
        // add relationships and data fields you need
        public List<Event> Events { get; set; }
        public List<AdministrativeUnit> AdministrativeUnits { get; set; }

    }
}