using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }
       // [ForeignKey(nameof(Comment))]
        //public int CommentId { get; set; }
        //public virtual Comment Comment { get; set; }


        //[ForeignKey(nameof(Replies))]
        //public int ReplyId { get; set; }
       

        //navigation property
        //public virtual List<Reply> Replies { get; set; } = new List<Reply>();

        [Required]
        public string Text { get; set; }
        [Required]
        public Guid Author { get; set; }

    }
}
