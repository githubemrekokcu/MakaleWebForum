using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("aticle_comments")]
    public class ArticleComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int articleCommentID { get; set; }

        [ForeignKey("article")]
        [Column("aticlecomments_refarticle_code")]
        [Required]
        public string articleCommentRefArticleCode { get; set; }


        [Column("articlecomments")]
        [Required]
        public string articleComment { get; set; }

        public virtual Article article { get; set; }
        public virtual User user { get; set; }
    }
}
