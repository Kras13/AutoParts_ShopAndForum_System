using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Services;
using AutoParts_ShopAndForum.Infrastructure.Data;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AutoParts_ShopAndForum_System.Test
{
    public class ProductServiceTest
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
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<ISubcategoryService, SubcategoryService>()
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
        public void ArgumentExceptionWhenUsingInexistantSubcategory()
        {
            Product product = new Product()
            {
                Name = "Test",
                SubcategoryId = 1,
                CreatorId = "1",
                ImageUrl = "asdasdas",
                Price = 20,
                Description = "Test"
            };

            var service = serviceProvider.GetService<IProductService>();

            Assert.Catch<ArgumentException>(() => service.Add(
                product.Name,
                product.Price,
                product.ImageUrl,
                product.Description,
                product.SubcategoryId,
                product.CreatorId));
        }

        [Test]
        public void ArgumentExceptionWhenInexistantUser()
        {
            var repo = serviceProvider.GetService<IRepository>();

            Category category = new Category()
            {
                Name = "Test",
                ImageUrl = "asdasdasd"
            };
            repo.Add<Category>(category);
            repo.SaveChanges();

            Subcategory subcategory = new Subcategory()
            {
                Category = category,
                Name = "Test"
            };
            repo.Add<Subcategory>(subcategory);
            repo.SaveChanges();

            Product product = new Product()
            {
                Name = "Test",
                Subcategory = subcategory,
                CreatorId = "does not exist",
                ImageUrl = "asdasdas",
                Price = 20,
                Description = "Test"
            };

            var service = serviceProvider.GetService<IProductService>();

            Assert.Catch<ArgumentException>(() => service.Add(
                product.Name,
                product.Price,
                product.ImageUrl,
                product.Description,
                product.SubcategoryId,
                product.CreatorId));
        }

        [Test]
        public void SuccessfulProductAdd()
        {
            var repo = serviceProvider.GetService<IRepository>();

            Category category = new Category()
            {
                Name = "Test",
                ImageUrl = "asdasdasd"
            };
            repo.Add<Category>(category);
            repo.SaveChanges();

            Subcategory subcategory = new Subcategory()
            {
                Category = category,
                Name = "Test"
            };
            repo.Add<Subcategory>(subcategory);
            repo.SaveChanges();

            Assert.That(category.Id > 0);
            Assert.That(subcategory.Id > 0);

            var user = repo.All<User>().FirstOrDefault();

            Product product = new Product()
            {
                Name = "Test",
                SubcategoryId = 1,
                CreatorId = "1",
                ImageUrl = "asdasdas",
                Price = 20,
                Description = "Test",
                Subcategory = subcategory,
                Creator = user
            };

            repo.Add<Product>(product);
            repo.SaveChanges();

            Assert.That(product.Id > 0);
        }
    }
}