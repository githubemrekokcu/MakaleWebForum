using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("aticle_likes")]
    public class ArticleLikes
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int articleLikesID { get; set; }


        public virtual Article article { get; set; }
        public virtual User user { get; set; }

    }
}
