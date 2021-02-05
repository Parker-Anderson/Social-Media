using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _authorId;

        public ReplyService(Guid AuthorId)
        {
            _authorId = AuthorId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Author = _authorId,
                    Text = model.Text,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.Author == _authorId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
