using AutoParts_ShopAndForum.Core.Contracts;
using AutoParts_ShopAndForum.Core.Models.Town;
using AutoParts_ShopAndForum.Infrastructure.Data.Common;
using AutoParts_ShopAndForum.Infrastructure.Data.Models;

namespace AutoParts_ShopAndForum.Core.Services
{
    public class TownService : ITownService
    {
        private readonly IRepository _repository;
        public TownService(IRepository repository)
        {
            _repository= repository;
        }

        public ICollection<TownModel> GetAll()
        {
            return this._repository
                .AllAsReadOnly<Town>()
                .Select(m => new TownModel() { Id = m.Id, Name = m.Name})
                .ToArray();
        }
    }
}
