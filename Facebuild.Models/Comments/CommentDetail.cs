using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models.Comments
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int BuildId { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
