using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models
{
    public class BuildListItem
    {
        public int BuildId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Likes { get; set;}
        public int UserLikes { get; set; }
        public int palletBlockCount { get; set; }
        [Display(Name ="(Created)")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
