using System;
using System.Collections.Generic;

#nullable disable

namespace tacobellMVC.Models
{
    public partial class Registration
    {
        public int RegistrationId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
