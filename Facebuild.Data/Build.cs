using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Data
{
    public class Build
    {
        [Key]
        public int BuildId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Photo { get; set; }
        public int Likes { get; set; }
        public IEnumerable<Guid> UsersLike { get; set; }
        public int palletBlockCount { get; set; }
        public int PalletId { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
        //[Required]
        //IEnumerable<>
    }
}
