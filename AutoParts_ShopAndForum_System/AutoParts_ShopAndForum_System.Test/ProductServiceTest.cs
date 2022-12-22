using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Services;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.Extensions.DependencyInjection;

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
        }

        [Test]
        public void ArgumentExceptionWhenUsingInexistantSubcategory()
        {
            Product product = new Product()
            {
                Name= "Test",
                SubcategoryId = 1,
                CreatorId="1",
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

        [TearDown]
        public void TearDown()
        {

        }
    }
}