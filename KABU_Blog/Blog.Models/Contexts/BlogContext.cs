using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Web;
using Blog.Models.Commons;
using Microsoft.AspNet.Identity;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims");
            modelBuilder.Entity<Setting>().Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

        public override int SaveChanges()
        {
            SetChanges();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync()
        {
            SetChanges();
            try
            {

                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException exception)
            {
                
                throw;
            }
            catch (Exception exception)
            {

                throw;
            }
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

        #region Helper(s)
        
        private void SetChanges()
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity is IMonitoredEntity)
                {
                    var entity = changedEntity as IMonitoredEntity;
                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.Created = DateTime.Now;
                        entity.CreatedId = HttpContext.Current.User.Identity.GetUserId();
                        entity.Updated = DateTime.Now;
                        entity.UpdatedId = HttpContext.Current.User.Identity.GetUserId();
                    }
                    else if (changedEntity.State == EntityState.Modified)
                    {
                        entity.Updated = DateTime.Now;
                        entity.UpdatedId = HttpContext.Current.User.Identity.GetUserId();
                    }
                }
            }
        }

        #endregion

    }
}
