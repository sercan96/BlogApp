using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Image { get; set; }

        // Relational Properties
        public virtual List<Post> Posts { get; set; } = new List<Post>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
