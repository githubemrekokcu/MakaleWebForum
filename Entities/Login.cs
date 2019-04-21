using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("login")]
    public class Login
    {

        [Key]
        [StringLength(25)]
        public string loginUserNameID { get; set; }

        [Column("login_userpassword")]
        [StringLength(15)]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string loginUserPassword { get; set; }

        [Column("refUserıd")]
        public virtual User user { get; set; }
    }
}
