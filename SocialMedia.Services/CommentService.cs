﻿





















































































































































































































































using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _authorId;
        public CommentService(Guid userId)
        {
            _authorId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Author = _authorId,
                    Text = model.Text,
                    Id = model.Id
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.Author == _authorId)
                    .Select(
                        e => new CommentListItem
                        {
                            Id = e.Id,
                            Text = e.Text,
                            //Replies = e.Replies

                        });
                return query.ToArray();
            }
        }
        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Comments
                    .Single(e => e.Id == id && e.Author == _authorId);
                return
                    new CommentDetail
                    {
                        Id = entity.Id,
                        Author = entity.Author,
                        Text = entity.Text,
                        //Replies = entity.Replies
                    };
            } 
        }
    }
}
