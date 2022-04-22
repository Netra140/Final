using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebuild.Models
{
    public class BuildCreate
    {
        //Add the rest of the variables
        [Required]
        [MinLength(2, ErrorMessage = "Please use at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Please use no more than 100 characters")]
        public string Name { get; set; }
        public string Photo { get; set; }
        public Data.Pallets.Pallet pallet { get; set; }
        public Blocks block { get; set; }

        [MaxLength(5000, ErrorMessage = "Please use no more than 5000 characters")]
        public string Description { get; set; }
        public int palletBlockCount { get; set; }
    }
    public enum Blocks
    {
        Stone,
        Deepslate,
        Brick,
        Spruce,
        Oak,
        Acacia,
        Birch,
        Dark_Oak,
        Mangrove,
        Jungle,
    }
}
