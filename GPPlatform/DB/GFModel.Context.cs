﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GPPlatform.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GPEntities : DbContext
    {
        public GPEntities()
            : base("name=GPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<UserInfoSet> UserInfoSet { get; set; }
        public virtual DbSet<UserSessionSet> UserSessionSet { get; set; }
    }
}
