using API.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
   public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Value> Values{get;set;}
        public DbSet<Activity> Activities {get;set;}
        public DbSet<UserActivity> UserActivities {get;set;}
        public DbSet<Photo> Photos {get;set;}
        public DbSet<UserFollowing> Followings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //define primary key
            builder.Entity<UserActivity>(x => x.HasKey(ua =>
                new { ua.AppUserId, ua.ActivityId }));  //build primary key combine this

            builder.Entity<UserActivity>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.UserActivities)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<UserActivity>()
                .HasOne(a => a.Activity)
                .WithMany(u => u.UserActivities)
                .HasForeignKey(a => a.ActivityId);

            builder.Entity<UserFollowing>(b => {
                b.HasKey( k => new {k.TergetId, k.ObserverId}); //build primary key combine this

                b.HasOne(o => o.Observer)
                    .WithMany(f => f.Followings)
                    .HasForeignKey(o => o.ObserverId)
                    .OnDelete(DeleteBehavior.Restrict);
                b.HasOne(o => o.tergate)
                    .WithMany(f => f.Followers)
                    .HasForeignKey(o => o.TergetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
