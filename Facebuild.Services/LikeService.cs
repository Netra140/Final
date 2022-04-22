using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebuild.Models.Likes;
using Facebuild.Data;
using Microsoft.AspNet.Identity;

namespace Facebuild.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        private readonly int _buildId;
        public LikeService(Guid userId, int buildId)
        {
            _userId = userId;
            _buildId = buildId;
        }

        public bool CreateLike(LikeCreate model, int postId)
        {
            var entity =
                new Like()
                {
                    UserId = _userId,
                    BuildId = postId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Like.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool TestforLikes(int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Like
                        .Where(e => e.UserId == _userId)
                        .Where(e => e.BuildId == buildId)
                        .Select(
                            e =>
                                    new LikeListItem
                                    {
                                        UserId = e.UserId,
                                        BuildId = e.BuildId,
                                    }
                               );
                return query.ToArray().Length >= 1;
            }
        }

        public IEnumerable<LikeListItem> GetLikes(int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Like
                        //.Where(e => e.UserId == _userId)
                        .Where(e => e.BuildId == buildId)
                        .Select(
                            e =>
                                    new LikeListItem
                                    {
                                        UserId = e.UserId,
                                        BuildId = e.BuildId,
                                    }
                               );
                return query.ToArray();
            }
        }

        public IEnumerable<LikeListItem> GetLikesByUser(int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Like
                        .Where(e => e.UserId == _userId)
                        .Where(e => e.BuildId == buildId)
                        .Select(
                            e =>
                                    new LikeListItem
                                    {
                                        UserId = e.UserId,
                                        BuildId = e.BuildId,
                                    }
                               );
                return query.ToArray();
            }
        }

        public bool DeleteLike(int LikeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                GetLikesByUser(LikeId).Count();
                var entity =
                    ctx
                        .Like
                        .Single(e => e.Id == LikeId && e.UserId == _userId);

                ctx.Like.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public LikeDelete GetLikeByIdForDel(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Like
                        .Single(e => e.BuildId == id && e.UserId == _userId);
                return
                    new LikeDelete
                    {
                        Id = entity.Id,
                        BuildId = entity.BuildId,
                        UserId = entity.UserId
                    };
            }
        }
        public LikeDetail GetLikeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Like
                        .Single(e => e.BuildId == id && e.UserId == _userId);
                return
                    new LikeDetail
                    {
                        BuildId = entity.BuildId,
                        //UserId = entity.UserId
                    };
            }
        }

    }
}
