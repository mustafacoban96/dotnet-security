using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Model
{
    [Table("tbl_productimage")]
    public partial class TblProductimage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("productcode")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Productcode { get; set; }

        [Column("productimage", TypeName = "image")]
        public byte[]? Productimage { get; set; }
    }
}