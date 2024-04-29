using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using BlogApp.Entity;
using System.Data;

namespace Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void FillTestData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogAppContext>();
            if(context != null)
            {
                if (context.Database.GetMigrations().Any()) // Bekleyen migrationlar varsa uygulanır. Database update gerektirmez
                {
                    context.Database.Migrate();
                }
                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Web Programlama" },
                        new Tag { Text = "Backend" },
                        new Tag { Text = "Frontend" },
                        new Tag { Text = "FullStack" },
                        new Tag { Text = "Php" }
                        );
                    context.SaveChanges();
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName="Sercan Sağlam"},
                        new User { UserName="Muhammet Emin Aydınalp"},
                        new User { UserName="Mehmet Taze"},
                        new User { UserName= "Ali Çalışkan" }
                        );
                    context.SaveChanges();
                }
                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.Net Core",
                            Content = "Asp.Net Core Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                        },
                        new Post
                        {
                            Title = "Php",
                            Content = "Php Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "3.jpg",
                            UserId = 1,
                        },
                        new Post
                        {
                            Title = "Django",
                            Content = "Django Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "2.jpg",
                            UserId = 2,
                        }       
                  );;
                    context.SaveChanges();
                }

            }
        }
    }
}
