using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("category")]
    public class Categories
    {
        [Key]
        [StringLength(10)]
        [Required]
        public string categoryCode { get; set; }

        [StringLength(50)]
        [Required]
        public string categoryName { get; set; }

        public virtual ICollection<Article> article{ get; set; }

    }
}
