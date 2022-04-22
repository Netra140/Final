using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models
{
    public class BuildDetail
    {
        public int BuildId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public BuildSheet buildSheet { get; set; }
        public string Description { get; set; }
        public string iframeSrc { get; set; }
        public string iframeSrcComments { get; set; }
        public int PalletId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public BuildDetail () {
            buildSheet = new BuildSheet(BuildId);
        }
    }
}
