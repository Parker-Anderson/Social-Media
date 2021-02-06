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
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Author = _userId,
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
                        .Where(e => e.Author == _userId)
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
        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.Id == id && e.Author == _userId);
                return
                    new ReplyDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        
                    };
            }
        }
    }
}
