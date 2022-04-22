using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models.Likes
{
    public class LikeCreate
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int BuildId { get; set; }
    }
}
