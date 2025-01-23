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
        
        public  DbSet<TblCustomer> TblCustomers {get; set;}
        public  DbSet<TblMenu> TblMenus { get; set; }
        public  DbSet<TblOtpManager> TblOtpManagers { get; set; }
        public  DbSet<TblProduct> TblProducts { get; set; }
        public  DbSet<TblProductimage> TblProductimages { get; set; }
        public  DbSet<TblPwdManger> TblPwdMangers { get; set; }
        public  DbSet<TblRefreshtoken> TblRefreshtokens { get; set; }
        public  DbSet<TblRole> TblRoles { get; set; }
        public  DbSet<TblRolepermission> TblRolepermissions { get; set; }
        public  DbSet<TblTempuser> TblTempusers { get; set; }
        public  DbSet<TblUser> TblUsers { get; set; }
        public  DbSet<Customermodal> customerdetail { get; set; }



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