using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models.Comments
{
    public class CommentListItem
    {
        public int id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public int BuildId { get; set; }
        [Display(Name ="Posted")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
