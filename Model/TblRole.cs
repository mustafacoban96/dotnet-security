using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace auth_jwt_refresh_mechanism.Model
{
    [Table("tbl_role")]
    public partial class TblRole
    {
        [Key]
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; } = null!;

        [Column("name")]
        [StringLength(200)]
        public string Name { get; set; } = null!;

        [Column("status")]
        public bool? Status { get; set; }
    }
}