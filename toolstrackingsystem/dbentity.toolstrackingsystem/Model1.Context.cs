﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbentity.toolstrackingsystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cangku_manage_dbEntities : DbContext
    {
        public cangku_manage_dbEntities()
            : base("name=cangku_manage_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sys_Menu_Info> Sys_Menu_Info { get; set; }
        public virtual DbSet<Sys_User_Role> Sys_User_Role { get; set; }
        public virtual DbSet<Sys_User_Info> Sys_User_Info { get; set; }
        public virtual DbSet<t_PersonInfo> t_PersonInfo { get; set; }
        public virtual DbSet<t_ToolCategoryInfo> t_ToolCategoryInfo { get; set; }
        public virtual DbSet<t_ToolInfo> t_ToolInfo { get; set; }
        public virtual DbSet<t_ScrapToolInfo> t_ScrapToolInfo { get; set; }
    }
}
