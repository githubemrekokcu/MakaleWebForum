namespace DataLogicLayer
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MakaleWebDB : DbContext
    {
        
        // Your context has been configured to use a 'MakaleWebDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataLogicLayer.MakaleWebDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MakaleWebDB' 
        // connection string in the application configuration file.
        public MakaleWebDB()
            : base("name=MakaleWebDB")
        {
            Database.SetInitializer(new BindFakeData());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Login> logins { get; set; }
        public virtual DbSet<Categories> categorys { get; set; }
        public virtual DbSet<Article> articles { get; set; }
        public virtual DbSet<ArticleLikes> articleLikes { get; set; }
        public virtual DbSet<ArticleComment> articleComments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}