using Facebuild.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models
{
    public class BuildSheet
    {
        public CommentCreate commentCreate { get; set; }
        public CommentListItem commentListItem { get; set; }
        public BuildSheet (int buildId)
        {
            commentCreate = new CommentCreate();
            commentListItem = new CommentListItem();
        }
    }
}
