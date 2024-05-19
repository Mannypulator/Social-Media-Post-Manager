using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Follow>? Following { get; set; }
        public ICollection<Post>? Posts { get; set; }

        public ICollection<Like>? Likes { get; set; }
    }
}