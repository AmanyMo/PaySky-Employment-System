using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Domain.Abstract
{
    public class AbstractUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }

    }
}
