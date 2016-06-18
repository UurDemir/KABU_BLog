using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Models.Contexts
{
    public class BlogContext : IdentityDbContext<User>
    {
        public BlogContext()
            : base("Main", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims");

            base.OnModelCreating(modelBuilder);
        }

        public static BlogContext Create()
        {
            return new BlogContext();
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleChange> ArticleChanges { get; set; }
        public DbSet<ArticleInfo> ArticleInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ForbiddenIp> ForbiddenIps { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMediae { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
