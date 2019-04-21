using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("article")]
    public class Article
    {
        [Key]
        [StringLength(10)]
        public string articleCodeID { get; set; }

        [Column("article_shareddate")]
        [Required]
        public DateTime articleSharedDate { get; set; }


        [Column("article_title")]
        [StringLength(100)]
        [Required]
        public string articleTitle { get; set; }

        [Column("article_content")]
        [Required]
        public string articleContent { get; set; }

        public virtual User user { get; set; }
        public virtual Categories category { get; set; }
        public virtual ICollection<ArticleLikes> likes { get; set; }
        public virtual ICollection<ArticleComment> comments { get; set; }


    }
}
