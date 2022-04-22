using Facebuild.Data;
using Facebuild.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Facebuild.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public int _buildId;
        public CommentService(Guid userId, int buildId)
        {
            _userId = userId;
            _buildId = buildId;
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.Id == model.Id);//  && e.UserId == _userId);

                entity.Content = model.Content;
                entity.UserId = model.UserId;
                _buildId = entity.BuildId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateComment(CommentCreate model, int postId)
        {
            var entity =
                new Comment()
                {
                    UserId = _userId,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now,
                    BuildId = postId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
       
        public IEnumerable<CommentListItem> GetComments(int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comment
                        //.Where(e => e.UserId == _userId)
                        .Where(e => e.BuildId == buildId)
                        .Select(
                            e =>
                                    new CommentListItem
                                    {
                                        id = e.Id,
                                        UserId = e.UserId,
                                        Content = e.Content,
                                        BuildId = e.BuildId,
                                        CreatedUtc = e.CreatedUtc
                                    }
                               );
                return query.ToArray();
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.Id == commentId);// && e.UserId == _userId);

                ctx.Comment.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.Id == id);// && e.UserId == _userId);
                return
                    new CommentDetail
                    {
                        Content = entity.Content,
                        BuildId = entity.BuildId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

    }
}
