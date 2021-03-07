﻿using System;
using System.Linq;
using System.Text.Json;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public override string ToString() => JsonSerializer.Serialize<AppUser>(this);
    }
}
