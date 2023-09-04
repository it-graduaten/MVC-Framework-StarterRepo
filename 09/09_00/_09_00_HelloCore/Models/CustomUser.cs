﻿using Microsoft.AspNetCore.Identity;

namespace _09_00_HelloCore.Models
{
    public class CustomUser: IdentityUser
    {
        [PersonalData]
        public string? Naam { get; set; }
        [PersonalData]
        public DateTime? Geboortedatum { get; set; }

    }
}
