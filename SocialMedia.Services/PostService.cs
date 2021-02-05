using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _userId;


        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate post)
        {
            var entity = new Post()
            {
                Title = post.Title,
                Text = post.Text,
                Author = _userId

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Posts
                    .Where(e => e.Author == _userId)
                    .Select(
                        e => new PostListItem
                        {
                            Id = e.Id,
                            Title = e.Title,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();

            }
        }
        public PostDetail GetPostById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(e => e.Id == id && e.Author == _userId);
                return new PostDetail
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Text = entity.Text,
                    Author = entity.Author,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        public bool UpdatePost(PostEdit post)
        {
            using (var ctx = new ApplicationDbContext())
            { var entity = ctx
                   .Posts
                   .Single(e => e.Id == post.Id && e.Author == _userId);

                entity.Title = post.Title;
                entity.Text = post.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
                    }
        }
        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(e => e.Id == id && e.Author == _userId);

                    ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
