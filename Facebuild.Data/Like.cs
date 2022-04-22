using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Data
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool like { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int BuildId { get; set; }
    }
}
