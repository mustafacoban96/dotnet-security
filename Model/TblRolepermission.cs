using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace auth_jwt_refresh_mechanism.Model
{
    [Table("tbl_rolepermission")]
    public partial class TblRolepermission
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("userrole")]
        [StringLength(50)]
        public string Userrole { get; set; } = null!;

        [Column("menucode")]
        [StringLength(50)]
        public string Menucode { get; set; } = null!;

        [Column("haveview")]
        public bool Haveview { get; set; }

        [Column("haveadd")]
        public bool Haveadd { get; set; }

        [Column("haveedit")]
        public bool Haveedit { get; set; }

        [Column("havedelete")]
        public bool Havedelete { get; set; }
        }
}