using System;
using System.Collections.Generic;
using System.Text;

namespace Net_Core_10_Domain.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt
        {
            get; set;
        }
    }
}
