using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureShare.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<PictureModel> Picture { get; set; }

        public DbSet<CommentModel> Comment { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
