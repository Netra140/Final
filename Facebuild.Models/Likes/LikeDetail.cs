using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models.Likes
{
    public class LikeDetail
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int BuildId { get; set; }
    }
}
