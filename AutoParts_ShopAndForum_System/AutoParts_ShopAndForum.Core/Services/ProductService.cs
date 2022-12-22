using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models;
using AutoParts_ShopAndForum.Core.Models.Product;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public const int AllProducts = -1;

        public int Add(
            string name,
            decimal price,
            string imageUrl,
            string description,
            int subcategoryId,
            string creatorId)
        {
            var subCategory = _repository
                .All<Subcategory>()
                .FirstOrDefault(e => e.Id == subcategoryId);

            if (subCategory == null) 
            {
                throw new ArgumentException("Subactegory not found");
            }

            var entity = new Product()
            {
                Name = name,
                Price = price,
                ImageUrl = imageUrl,
                Description = description,
                SubcategoryId = subcategoryId,
                CreatorId = creatorId
            };

            _repository.Add(entity);
            _repository.SaveChangesAsync();

            return entity.Id;
        }

        public ProductQueryModel GetQueried(
            int currentPage,
            int productsPerPage,
            string searchCriteria,
            ProductSorting sorting,
            int? categoryId = null,
            ICollection<int> selectedSubcategories = null)
        {
            var entities = _repository
                .AllAsReadOnly<Product>()
                .Include(c => c.Subcategory)
                .ThenInclude(c => c.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchCriteria))
            {
                entities = entities.Where(e => e.Name.ToLower().Contains(searchCriteria.ToLower()));
            }

            if (selectedSubcategories != null && selectedSubcategories.Count() > 0)
            {
                entities = entities
                    .Where(e => selectedSubcategories.Any(s => s == e.SubcategoryId));
            }

            switch (sorting)
            {
                case ProductSorting.PriceAscending:
                    entities = entities
                        .OrderBy(p => p.Price);
                    break;
                case ProductSorting.PriceDescending:
                    entities = entities
                        .OrderByDescending(p => p.Price);
                    break;
                case ProductSorting.DateAscenging:
                    entities = entities
                        .OrderBy(p => p.Id);
                    break;
                case ProductSorting.DateDescending:
                    entities = entities
                        .OrderByDescending(p => p.Id);
                    break;
                case ProductSorting.NameAscending:
                    entities = entities
                        .OrderBy(p => p.Name);
                    break;
                case ProductSorting.NameDescending:
                    entities = entities
                        .OrderByDescending(p => p.Name);
                    break;
            }

            if (categoryId.HasValue)
            {
                entities = entities
                    .Where(e => e.Subcategory.CategoryId == categoryId);
            }

            var result = new ProductQueryModel()
            {
                TotalProductsWithoutPagination = entities.Count(),
                Products = entities
                .Skip((currentPage - 1) * productsPerPage)
                .Select(e => new ProductModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    CategoryId = categoryId.HasValue ? categoryId.Value : -1,
                    SubcategoryId = e.SubcategoryId,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    Price = e.Price
                }).ToArray()
            };

            if (productsPerPage > AllProducts)
            {
                result.Products = result.Products.Take(productsPerPage).ToArray();
            }

            return result;
        }

        public ProductModel GetById(int id)
        {
            var model = _repository.AllAsReadOnly<Product>().FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                return new ProductModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price,
                    SubcategoryId = model.SubcategoryId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Creatorid = model.CreatorId
                };
            }
            else
            {
                return null;
            }
        }

        public ProductModel Update(ProductModel product)
        {
            var model = _repository.All<Product>()
                .FirstOrDefault(e => e.Id == product.Id);

            if (model == null)
            {
                throw new ArgumentException("ProductService.Update -> product with the selected id can not be found");
            }

            model.Name = product.Name;
            model.Price = product.Price;
            model.ImageUrl= product.ImageUrl;
            model.Description = product.Description;
            model.SubcategoryId = product.SubcategoryId;

            _repository.SaveChanges();

            return product;
        }
    }
}
