using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Services.Abstractions;

namespace Salvation.Library.Services.Implementations
{
    internal class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<int> CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>?> GetAllAsync()
        {
            var getAllResult = await _unitOfWork.Category.GetAllAsync();
            return getAllResult;
        }

        public async Task<Category?> GetAsync(string id)
        {
            var getOneResult = await _unitOfWork.Category.GetAsync(id);
            return getOneResult;
        }

        public Task<bool> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
