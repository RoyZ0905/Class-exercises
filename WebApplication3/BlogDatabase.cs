﻿namespace WebApplication3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogDatabase : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“NewsDatabase”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“WebApplication3.NewsDatabase”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“NewsDatabase”
        //连接字符串。
        public BlogDatabase()
            : base("name=BlogDatabase")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

         public virtual DbSet<Blog> Blogs{ get; set; }
         public virtual DbSet<BlogBody> BlogBodys{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var blogTable = modelBuilder.Entity<Blog>();
            var blogbodyTable = modelBuilder.Entity<BlogBody>();

            //blogTable.Property(o => o.Id).IsRequired();
            blogTable.HasKey(o => o.Id);

            //blogArtticleTable.Property(o => o.Id).IsRequired();
            blogbodyTable.HasKey(o => o.Id);


            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// 博客
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 博客
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// 博客主体
    /// </summary>
    public class BlogBody
    {
        public int Id { get; set; }

        public int BlogId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>

        public string Body { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime DateCreated { get; set; }
    }
}