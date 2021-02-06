using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(240)]
        public string Text { get; set; }
        public Guid Author { get; set; }

    }
}
