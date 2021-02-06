using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentDbContext: DbContext
    {
        public CommentDbContext()
            : base("DefaultConnection") { }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}
