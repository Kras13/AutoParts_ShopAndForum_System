using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Services;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoParts_ShopAndForum_System.Test
{
    public class PostServiceTest
    {
        private ServiceProvider serviceProvider; // potential bug -> mayybe use ServiceProvider -> or 
        private InMemoryDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IPostService, PostService>()
                .BuildServiceProvider();

            SeedTown();
            SeedUser();
        }

        private void SeedUser()
        {
            string adminEmail = "admin@abv.bg";
            string adminPassword = "admin123";

            User user = new User()
            {
                Email = adminEmail,
                UserName = adminEmail,
                FirstName = "Admin",
                LastName = "Adminchev",
                EGN = "0112222333",
                TownId = 1,
                PasswordHash = adminPassword
            };

            var repo = serviceProvider.GetService<IRepository>();
            repo.Add<User>(user);
            repo.SaveChanges();
        }

        private void SeedTown()
        {
            var repo = serviceProvider.GetService<IRepository>();

            Town town = new Town()
            {
                Name = "Stz"
            };

            repo.Add<Town>(town);

            repo.SaveChanges();
        }

        [Test]
        public void ArgumentExceptionWhenUsingInexistantCategory()
        {
            var postCategory = new PostCategory()
            {
                Name = "test",
                Description = "test",
                ImageUrl = "test"
            };

            var repo = serviceProvider.GetService<IRepository>();

            repo.Add<PostCategory>(postCategory);
            repo.SaveChanges();

            var post = new Post()
            {
                Title = "Test",
                Content = "Test",
                CraetorId = "fake",
                CreatedOn = DateTime.Now,
                PostCategory = postCategory,
            };

            var service = serviceProvider.GetService<IPostService>();

            Assert.Catch<ArgumentException>(() => service.Add(post.Title, post.Content, post.PostCategoryId, post.CraetorId));
        }
    }
}
