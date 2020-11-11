using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoDWorldBackEnd.DAL.Entities;
using TwoDWorldBackEnd.DAL.Entities.Auth;

namespace TwoDWorldBackEnd.DAL
{
    public class EFContext : IdentityDbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Title> Titles { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<TitleGenre> TitleGenres { get; set; }

        public DbSet<UserAdditionalInfo> userAdditionalInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.UserAdditionalInfo)
                .WithOne(ui => ui.User)
                .HasForeignKey<UserAdditionalInfo>(ul => ul.Id);
            base.OnModelCreating(builder);
        }
    }
}
