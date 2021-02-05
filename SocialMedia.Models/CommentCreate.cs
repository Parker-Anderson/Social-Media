using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int Id { get; set; }
        public List<Reply> Replies { get; set; }
        public Guid Author { get; set; }
    }
}
