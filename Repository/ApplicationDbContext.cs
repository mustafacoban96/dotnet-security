using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_jwt_refresh_mechanism.Dtos;
using auth_jwt_refresh_mechanism.Model;
using Microsoft.EntityFrameworkCore;

namespace auth_jwt_refresh_mechanism.Repository
{
    public partial class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        
        public virtual DbSet<TblCustomer> TblCustomers {get; set;}

        public virtual DbSet<TblMenu> TblMenus { get; set; }

        public virtual DbSet<TblOtpManager> TblOtpManagers { get; set; }

        public virtual DbSet<TblProduct> TblProducts { get; set; }

        public virtual DbSet<TblProductimage> TblProductimages { get; set; }

        public virtual DbSet<TblPwdManger> TblPwdMangers { get; set; }

        public virtual DbSet<TblRefreshtoken> TblRefreshtokens { get; set; }

        public virtual DbSet<TblRole> TblRoles { get; set; }

        public virtual DbSet<TblRolepermission> TblRolepermissions { get; set; }

        public virtual DbSet<TblTempuser> TblTempusers { get; set; }

        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<Customermodal> customerdetail { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblTempuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_tempuser1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}