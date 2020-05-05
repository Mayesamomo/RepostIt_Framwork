﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepostIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Community> community { get; set; }

        public DbSet<Post> posts { get; set; }

        public DbSet<Comment> comments { get; set; }
        public DbSet<Like> likes { get; set; }
        public DbSet<Dislike> dislikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Community>().HasData(new Community
            {
                Id = 200,
                communityType = "Funny",
                name = "Admin"
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                id = 100,
                showTitle = "Office MEME",
                communityId = 200,
                url = "https://i.kym-cdn.com/photos/images/original/001/488/398/944.jpeg",
                description = "2020 was awesome",
                name = "Admin"
            });
            modelBuilder.Entity<Like>().HasData(new Like
            {
                id = 300,
                postId = 100,
                username = "Admin"
            });

            modelBuilder.Entity<Community>().HasData(new Community
            {
                Id = 201,
                communityType = "Sad",
                name = "Admin"
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                id = 101,
                showTitle = "Sheldon",
                communityId = 200,
                url = "https://starecat.com/content/wp-content/uploads/all-of-a-sudden-everybody-has-become-sheldon-big-bang-theory-coronavirus.jpg",
                description = "Big COVID-19 Bang",
                name = "Admin"
            });
            modelBuilder.Entity<Like>().HasData(new Like
            {
                id = 301,
                postId = 101,
                username = "Admin"
            });


            modelBuilder.Entity<Community>().HasData(new Community
            {
                Id = 202,
                communityType = "Trololo",
                name = "Admin"
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                id = 102,
                showTitle = "WOW",
                communityId = 200,
                url = "data:image/jpeg;base64,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",
                description = "Magic",
                name = "Admin"
            });
            modelBuilder.Entity<Like>().HasData(new Like
            {
                id = 302,
                postId = 103,
                username = "Admin"
            });


            modelBuilder.Entity<Community>().HasData(new Community
            {
                Id = 203,
                communityType = "Sport",
                name = "Admin"
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                id = 104,
                showTitle = "Great MEME",
                communityId = 200,
                url = "https://i.redd.it/2d6a36bq6mw41.png",
                description = "Awesome",
                name = "Admin"
            });
            modelBuilder.Entity<Like>().HasData(new Like
            {
                id = 303,
                postId = 104,
                username = "Admin"
            });

        }

    }

}


