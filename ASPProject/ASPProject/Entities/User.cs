using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Entities
{
    public class User
    {
        [Key]
        [ForeignKey("UserDetails")]
        public int UserDetailsId { get; set; }

        public string Email { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }
        public virtual UserDetails UserDetails { get; set; }
    }
}