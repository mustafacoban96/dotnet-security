using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Model
{
    [Table("tbl_refreshtoken")]
    public partial class TblRefreshtoken
    {
        [Key]
        [Column("userid")]
        [StringLength(50)]
        [Unicode(false)]
        public string Userid { get; set; } = null!;

        [Column("tokenid")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Tokenid { get; set; }

        [Column("refreshtoken")]
        [Unicode(false)]
        public string? Refreshtoken { get; set; }
    }
}