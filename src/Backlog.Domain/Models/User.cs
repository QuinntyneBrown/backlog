using System;
using System.Collections.Generic;

namespace Backlog.Domain.Models
{    
    public class User
    {
        public User()
        {

        }

        public Guid UserId { get; set; }     
        public byte[] Salt { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public string Fullname { get { return $"{Firstname} {Lastname}"; } }        
        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();        
        public virtual Profile Profile { get; set; }
    }
}
