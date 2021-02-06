using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(150, ErrorMessage = "Only 150 characters allowed in your post.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(8000)]
        public string Text { get; set; }
        public Guid Author { get; set; }
    }
}
