using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_code_id")]
        [StringLength(10,ErrorMessage ="{0} alanı max. {1} karakter içermeli" )]
        public string userCodeID { get; set; }

        [Column("user_firstname")]
        [StringLength(50)]
        [Required(ErrorMessage ="{0} alanı gereklidir.")]
        public string userFirstName { get; set; }

        [Column("user_lastname")]
        [StringLength(50)]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string userLastName { get; set; }

        [Column("user_dateofdate")]
        [Required]
        public DateTime userDateOfBirth { get; set; }
    
        public virtual ICollection<Login> login  { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

    }
}
