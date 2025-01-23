using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace auth_jwt_refresh_mechanism.Model
{
    [Table("tbl_pwdManger")]
    public class TblPwdManger
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; } = null!;

        [Column("password")]
        [StringLength(200)]
        public string Password { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
}