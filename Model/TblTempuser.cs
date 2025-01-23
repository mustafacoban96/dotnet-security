using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Model
{
    [Table("tbl_tempuser")]
    public partial class TblTempuser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = null!;

        [Column("name")]
        [StringLength(250)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [Column("email")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Email { get; set; }

        [Column("phone")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Phone { get; set; }

        [Column("password")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Password { get; set; }
    }
}