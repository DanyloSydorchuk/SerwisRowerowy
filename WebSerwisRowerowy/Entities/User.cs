using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }

    }
}
