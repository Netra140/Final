using Facebuild.Data;
using Facebuild.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Facebuild.Services
{
    public class BuildService
    {
        private readonly Guid _userId;

        public BuildService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBuild(BuildCreate model)
        {
            var entity =
                new Build()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Photo = model.Photo,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now,
                    palletBlockCount = model.palletBlockCount
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Build.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /*public bool ApplyPallet (int buildId, )
        {
            return true;
        }*/

        public IEnumerable<BuildListItem> GetBuilds()
        {
            
            using (var ctx = new ApplicationDbContext())
            {
                //LikeCount();
                var query =
                    ctx
                        .Build
                        //.Where(e => e.OwnerId ==_userId)
                        .Select(
                            e =>
                                    new BuildListItem
                                    {
                                        BuildId = e.BuildId,
                                        Name = e.Name,
                                        Photo = e.Photo,
                                        Likes = e.Likes,
                                        //UserLikes = CreateLikeService(e.BuildId).GetLikes(e.BuildId).Contains(_userId),
                                        CreatedUtc = e.CreatedUtc,
                                        palletBlockCount = e.palletBlockCount
                                    }
                               );
                return query.ToArray();
            }
        }

        public IEnumerable<BuildListItem> GetBuilds(Guid accountId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                //LikeCount();
                var query =
                    ctx
                        .Build
                        .Where(e => e.OwnerId == accountId)
                        .Select(
                            e =>
                                    new BuildListItem
                                    {
                                        BuildId = e.BuildId,
                                        Name = e.Name,
                                        Photo = e.Photo,
                                        Likes = e.Likes,
                                        //UserLikes = CreateLikeService(e.BuildId).GetLikes(e.BuildId).Contains(_userId),
                                        CreatedUtc = e.CreatedUtc,
                                        palletBlockCount = e.palletBlockCount
                                    }
                               );
                return query.ToArray();
            }
        }

        public bool UpdateBuild(BuildEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Build
                        .Single(e => e.BuildId == model.BuildId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Photo = model.Photo;
                entity.Description = model.Description;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool ApplyPallet(int palId, int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Build
                        .Single(e => e.BuildId == buildId && e.OwnerId == _userId);

                entity.PalletId = palId;
                //entity.UsersLike = CreateLikeService(e.BuildId).GetLikes(e.BuildId).Contains(_userId)

                return ctx.SaveChanges() == 1;
            }
        }
        public bool LikeCount(int likes, int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Build
                        .Single(e => e.BuildId == buildId && e.OwnerId == _userId);

                entity.Likes = likes;
                //entity.UsersLike = CreateLikeService(e.BuildId).GetLikes(e.BuildId).Contains(_userId)

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBuild (int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Build
                        .Single(e => e.BuildId == buildId && e.OwnerId == _userId);

                ctx.Build.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public BuildDetail GetBuildById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Build
                        .Single(e => e.BuildId == id && e.OwnerId == _userId);
                return
                    new BuildDetail
                    {
                        BuildId = entity.BuildId,
                        Name = entity.Name,
                        Photo = entity.Photo,
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        iframeSrc = "../../Pallet/Details/" + entity.PalletId.ToString(),
                        iframeSrcComments = "../../Comment/List/" + entity.BuildId.ToString()
                    };
            }
        }
        private LikeService CreateLikeService(int buildId)
        {
            var userId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
            var service = new LikeService(userId, buildId);
            return service;
        }
    }
}
