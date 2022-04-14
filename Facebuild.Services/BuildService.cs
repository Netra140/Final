using Facebuild.Data;
using Facebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Build.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BuildListItem> GetBuilds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Build
                        .Where(e => e.OwnerId ==_userId)
                        .Select(
                            e =>
                                    new BuildListItem
                                    {
                                        BuildId = e.BuildId,
                                        Name = e.Name,
                                        CreatedUtc = e.CreatedUtc
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
                entity.Description = model.Description;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

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
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}
