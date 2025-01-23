using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Model
{
    [Table("tbl_product")]
    public partial class TblProduct
    {
        [Key]
        [Column("code")]
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = null!;

        [Column("name")]
        [Unicode(false)]
        public string? Name { get; set; }

        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
    }
}