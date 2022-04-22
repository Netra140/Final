using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models.Comments
{
    public class CommentCreate
    {
        [Required]
        public string Content { get; set; }
        //[Required]
        public int BuildId { get; set; }

        public CommentCreate ()
        {

        }

        public CommentCreate (int buildId)
        {
            BuildId = buildId;
        }
    }
}
